using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    public class DecodeManager
    {
        public string NoDecode(string data)
        {
            return data;
        }

        public string Decode(string data, byte[,] matrix)
        {
            var parityMatrix = matrix;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i = i + matrix.GetLength(0))
            {
                var decodedVector = DecodeVector(data.Substring(i, matrix.GetLength(0)), matrix);
                sb.Append(decodedVector);
            }

            return sb.ToString();
        }

        private string DecodeVector(string vector, byte[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            new MatrixManager().GenerateParityCheckFromGeneratingMatrix(matrix);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int answer = 0;
                for (int j = 0; j < vector.Length; j++)
                {
                    if (vector[j] == '1' && matrix[j, i] == 1)
                    {
                        answer = answer == 0 ? 1 : 0;
                    }
                }

                sb.Append(Convert.ToInt32(answer));
            }

            var errorPlace = Convert.ToInt64(sb.ToString(), 2);

            if (errorPlace != 0)
            {
                if (vector.Length <= errorPlace)
                {
                    StringBuilder result = new StringBuilder(vector);

                    if (result[Convert.ToInt32(errorPlace) - 1] == '0')
                        result[Convert.ToInt32(errorPlace) - 1] = '1';
                    else
                        result[Convert.ToInt32(errorPlace) - 1] = '0';

                    return result.ToString();
                }
            }
            return vector;
        }
    }
}
