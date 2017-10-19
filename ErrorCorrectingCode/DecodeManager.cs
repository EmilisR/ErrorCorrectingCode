using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    public class DecodeManager
    {
        private byte[,] parityMatrix;
        private byte[,] generatingMatrix;
        private MatrixManager manager = new MatrixManager();
        private Dictionary<byte[], byte[]> SindromeCosetsTable = new Dictionary<byte[], byte[]>();
        public string NoDecode(string data)
        {
            return data;
        }

        public string Decode(string data, byte[,] matrix)
        {
            var dataLong = data.Length;
            PrepareForDecoding(matrix);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i = i + matrix.GetLength(1))
            {
                try
                {
                    var decodedVector = DecodeVector(data.Substring(i, matrix.GetLength(1)).Select(x => (byte)char.GetNumericValue(x)).ToArray());
                    sb.Append(string.Join("", decodedVector.Select(x => x.ToString()).ToArray()));
                }
                catch { }
            }

            return sb.ToString();
        }

        private void PrepareForDecoding(byte[,] matrix)
        {
            parityMatrix = manager.GenerateParityCheckFromGeneratingMatrix(matrix);
            generatingMatrix = matrix;
            SindromeCosetsTable = GenerateSindromeCosetsTable(matrix.GetLength(1));
        }

        private Dictionary<byte[], byte[]> GenerateSindromeCosetsTable(int width)
        {
            var dict = new Dictionary<byte[], byte[]>();

            for (int i = 0; i < Math.Pow(2, width); i++)
            {
                var vector = Convert.ToString(i, 2).PadLeft(width, '0').Select(x => (byte)char.GetNumericValue(x)).ToArray();
                var sindrome = manager.GetSindrome(parityMatrix, vector);
                if (!dict.Values.Any(x => x.SequenceEqual(sindrome)))
                    dict.Add(vector, sindrome);
            }

            return dict;
        }

        private byte[] DecodeVector(byte[] vector)
        {
            

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= vector.Length; i++)
            {
                var sindrome = manager.GetSindrome(parityMatrix, vector);

                var weight = manager.GetWeightOfVector(SindromeCosetsTable.FirstOrDefault(x => x.Value.SequenceEqual(sindrome)).Key);

                if (weight == 0)
                    return manager.MultiplyMatrixAndVector(generatingMatrix, vector);

                var errorVector = new byte[vector.Length];
                errorVector[i] = 1;
                errorVector = manager.AddVector(errorVector, vector);

                var errorSindrome = manager.GetSindrome(parityMatrix, errorVector);

                var errorWeight = manager.GetWeightOfVector(SindromeCosetsTable.FirstOrDefault(x => x.Value.SequenceEqual(errorSindrome)).Key);

                if (errorWeight < weight)
                    vector = errorVector;
            }
            return null;
        }
    }
}
