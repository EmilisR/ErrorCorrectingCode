using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCorrectingCode
{
    /// <summary>
    /// Klasė skirta vektorių atkodavimui
    /// </summary>
    public class DecodeManager
    {
        private byte[,] parityMatrix;
        private byte[,] generatingMatrix;
        private MatrixManager manager = new MatrixManager();
        private Dictionary<byte[], byte[]> SindromeCosetsTable = new Dictionary<byte[], byte[]>();
        private Dictionary<byte[], byte[]> EncodingTable = new Dictionary<byte[], byte[]>();

        /// <summary>
        /// Atkoduoja binario pavidalo informaciją
        /// </summary>
        /// <param name="data">Dvinario pavidalo informacija</param>
        /// <param name="matrix">Generuojanti matrica</param>
        /// <returns>Atkoduota dvinario pavidalo informacija</returns>
        public string Decode(string data, byte[,] matrix)
        {
            PrepareForDecoding(matrix);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i = i + matrix.GetLength(1))
            {
                try
                {
                    var decodedVector = DecodeVector(data.Substring(i, matrix.GetLength(1)).Select(x => (byte)char.GetNumericValue(x)).ToArray());
                    sb.Append(string.Join("", decodedVector.Select(x => x.ToString())));
                }
                catch { }
            }

            var result = sb.ToString();
            var lastOne = result.LastIndexOf('1');
            result = result.Substring(0, lastOne);
            return result;
        }

        /// <summary>
        /// Atkoduoja vieną vektorių
        /// </summary>
        /// <param name="data">Vektorius dvinariu pavidalu</param>
        /// <param name="matrix">Generuojanti matrica</param>
        /// <returns>Atkoduotas vektorius, atkoduotas vektorius su kodu</returns>
        public Tuple<string, string> DecodeOneVector(string data, byte[,] matrix)
        {
            PrepareForDecoding(matrix);
            var decodedVector = DecodeVector(data.Select(x => (byte)char.GetNumericValue(x)).ToArray());
            var decodedVectorWithCode = EncodingTable[decodedVector];
            return new Tuple<string, string>(string.Join("", decodedVector.Select(x => x.ToString())), string.Join("", decodedVectorWithCode.Select(x => x.ToString())));
        }

        /// <summary>
        /// Sugeneruoja visa informacija reikalinga atkodavimui: kontrolinė matrica, atkodavimo lentelė, klasių lyderių - sindromų lentelė
        /// </summary>
        /// <param name="matrix">Generuojanti matrica</param>
        public void PrepareForDecoding(byte[,] matrix)
        {
            parityMatrix = manager.GenerateParityCheckFromGeneratingMatrix(matrix);
            generatingMatrix = matrix;
            EncodingTable = manager.GetEncodingTable(matrix, matrix.GetLength(0));
            SindromeCosetsTable = GenerateSindromeCosetsTable(matrix.GetLength(1));
        }

        /// <summary>
        /// Sugeneruoja visų galimų kodo žodžių lentelę
        /// </summary>
        /// <param name="width">Kodo ilgis</param>
        /// <param name="count">Galimų žodžių kiekis</param>
        /// <returns>Visi galimi vektoriai</returns>
        private List<byte[]> GenerateAllVectorsTable(int width, int count)
        {
            var list = new List<byte[]>();
            for (int i = 0; i < count; i ++)
            {
                list.Add(Convert.ToString(i, 2).PadLeft(width, '0').Select(x => (byte)char.GetNumericValue(x)).ToArray());
            }
            return list;
        }

        /// <summary>
        /// Sugeneruoja klasių lyderių - sindromų lentelę
        /// </summary>
        /// <param name="width">Kodo ilgis</param>
        /// <returns>Žodynas iš klasių lyderių - sindromų porų</returns>
        private Dictionary<byte[], byte[]> GenerateSindromeCosetsTable(int width)
        {
            var dict = new Dictionary<byte[], byte[]>();
            bool newCossetLeader = true;
            var allVectors = GenerateAllVectorsTable(generatingMatrix.GetLength(1), (int)(Math.Pow(2, generatingMatrix.GetLength(0)) * Math.Pow(2, generatingMatrix.GetLength(1) - generatingMatrix.GetLength(0)))).ToList();
            int weight = 0;

            while (dict.Count < Math.Pow(2, generatingMatrix.GetLength(1) - generatingMatrix.GetLength(0)))
            {
                newCossetLeader = true;
                while (newCossetLeader)
                {
                    var vector = allVectors.Where(x => x.Where(y => y != 0).Count() == weight).FirstOrDefault();
                    if (vector != null)
                    {
                        var sindrome = manager.GetSindrome(parityMatrix, vector);
                        if (!dict.Values.Any(x => x.SequenceEqual(sindrome)))
                        {
                            dict.Add(vector, sindrome);
                            newCossetLeader = false;
                            allVectors.Remove(vector);
                        }
                        else
                            allVectors.Remove(vector);
                    }
                    else
                        weight++;
                }
            }
            return dict;
        }

        /// <summary>
        /// Dekoduoja vektorių step-by-step atkodavimu
        /// </summary>
        /// <param name="vector">Dvinario pavidalo vektorius</param>
        /// <returns>Atkoduotas vektorius dvinariu pavidalu</returns>
        public byte[] DecodeVector(byte[] vector)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= vector.Length; i++)
            {
                //Gaunamas vektoriaus sindromas
                var sindrome = manager.GetSindrome(parityMatrix, vector);

                //Apskaičiuojamas sindromo svoris
                var weight = manager.GetWeightOfVector(SindromeCosetsTable.FirstOrDefault(x => x.Value.SequenceEqual(sindrome)).Key);

                //Jei svoris lygus 0, atkoduojame esamu vektoriumi
                if (weight == 0)
                    return EncodingTable.Where(x => x.Value.SequenceEqual(vector)).First().Key;

                var errorVector = new byte[vector.Length];
                errorVector[i] = 1;

                //Pridedame klaidų vektorių prie vektoriaus
                errorVector = manager.AddVector(errorVector, vector);

                //Gauname klaidų vektoriaus sindromą
                var errorSindrome = manager.GetSindrome(parityMatrix, errorVector);

                //Gauname klaidų vektoriaus sindromo svorį
                var errorWeight = manager.GetWeightOfVector(SindromeCosetsTable.FirstOrDefault(x => x.Value.SequenceEqual(errorSindrome)).Key);

                // Jei klaidų vektoriaus sindromo svoris mažesnis nei vektoriaus sindromo svoris, 
                // vektoriui priskiriame esamą klaidų vektorių ir tęsiame
                if (errorWeight < weight)
                    vector = errorVector;
            }
            return null;
        }
    }
}
