using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCorrectingCode
{
    /// <summary>
    /// Klasė skirta vektorių užkodavimui
    /// </summary>
    class EncodeManager
    {
        private MatrixManager matrixManager = new MatrixManager();
        private Dictionary<byte[], byte[]> EncodingTable = new Dictionary<byte[], byte[]>();

        /// <summary>
        /// Užkoduoja dvinario pavidalo pranešimą pagal generuojančią matricą
        /// </summary>
        /// <param name="data">Dvinario pavidalo pranešimas</param>
        /// <param name="matrix">Generuojanti matrica</param>
        /// <returns>Užkoduotas dvinario pavidalo pranešimas</returns>
        public string Encode(string data, byte[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            //Užkoduoja visą pranešimą, išskyrus paskutinį vektorių
            for (int i = 0; i <= data.Length - matrix.GetLength(0); i = i + matrix.GetLength(0))
            {
                var encodedVector = EncodeVector(data.Substring(i, matrix.GetLength(0)).Select(x => (byte)char.GetNumericValue(x)).ToArray(), matrix);
                sb.Append(string.Join("", encodedVector.Select(x => x.ToString())));
            }
            //Jei pranešimo ilgis nedalus iš vektoriaus ilgio, paskutinio vektoriaus gale pridedam vieną 1 ir likusius 0, iki kol vektorius bus tinkamo ilgio
            if (data.Length % matrix.GetLength(0) != 0)
            {
                var notFullVector = data.Substring(data.Length - matrix.GetLength(0) + 1, data.Length % matrix.GetLength(0));
                var fullVector = notFullVector.PadRight(notFullVector.Length + 1, '1').PadRight(matrix.GetLength(0), '0');
                var encodedVector = EncodeVector(fullVector.Select(x => (byte)char.GetNumericValue(x)).ToArray(), matrix);
                sb.Append(string.Join("", encodedVector.Select(x => x.ToString())));
            }
            //Jei pranešimo ilgis dalus iš vektoriaus ilgio, pridedam vieną papildomą vektorių, kurio pirmas elementas yra 1, o likę - 0
            else
            {
                var encodedVector = EncodeVector("1".PadRight(matrix.GetLength(0), '0').Select(x => (byte)char.GetNumericValue(x)).ToArray(), matrix);
                sb.Append(string.Join("", encodedVector.Select(x => x.ToString())));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Užkoduoja vektorių pagal generuojančią matricą
        /// </summary>
        /// <param name="vector">Vektorius dvinariu pavidalu</param>
        /// <param name="matrix">Generuojanti matrica</param>
        /// <returns>Užkoduotas vektorius dvinariu pavidalu</returns>
        public byte[] EncodeVector(byte[] vector, byte[,] matrix)
        {
            return matrixManager.MultiplyMatrixAndVector(matrixManager.TransposeMatrix(matrix), vector);
        }
    }
}
