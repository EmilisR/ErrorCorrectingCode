using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    class EncodeManager
    {
        private MatrixManager matrixManager = new MatrixManager();

        public string NoEncode(string data)
        {
            return data;
        }

        public string Encode(string data, byte[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            
            var transposed = matrixManager.TransposeMatrix(matrix);
            for (int i = 0; i < data.Length - matrix.GetLength(0); i = i + matrix.GetLength(0))
            {
                var encodedVector = EncodeVector(data.Substring(i, matrix.GetLength(0)).Select(x => (byte)char.GetNumericValue(x)).ToArray(), transposed);
                sb.Append(string.Join("", encodedVector.Select(x => x.ToString()).ToArray()));
            }

            return sb.ToString();
        }

        private byte[] EncodeVector(byte[] vector, byte[,] matrix)
        {
            return matrixManager.MultiplyMatrixAndVector(matrix, vector);
        }
    }
}
