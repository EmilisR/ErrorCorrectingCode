using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{

    /// <summary>
    /// 
    /// </summary>
    class EncodeManager
    {
        private MatrixManager matrixManager = new MatrixManager();
        private Dictionary<byte[], byte[]> EncodingTable = new Dictionary<byte[], byte[]>();

        public string NoEncode(string data)
        {
            return data;
        }

        public string Encode(string data, byte[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i <= data.Length - matrix.GetLength(0); i = i + matrix.GetLength(0))
            {
                var encodedVector = EncodeVector(data.Substring(i, matrix.GetLength(0)).Select(x => (byte)char.GetNumericValue(x)).ToArray(), matrix);
                sb.Append(string.Join("", encodedVector.Select(x => x.ToString())));
            }

            return sb.ToString();
        }

        public byte[] EncodeVector(byte[] vector, byte[,] matrix)
        {
            return matrixManager.MultiplyMatrixAndVector(matrixManager.TransposeMatrix(matrix), vector);
        }
    }
}
