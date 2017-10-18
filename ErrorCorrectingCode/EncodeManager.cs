using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    class EncodeManager
    {
        public string NoEncode(string data)
        {
            return data;
        }

        public string Encode(string data, byte[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length - matrix.GetLength(1); i = i + matrix.GetLength(1))
            {
                var encodedVector = EncodeVector(data.Substring(i, matrix.GetLength(1)), matrix);
                sb.Append(encodedVector);
            }

            return sb.ToString();
        }

        private string EncodeVector(string vector, byte[,] matrix)
        {
            var vectors = new List<string>();
            var rows = new List<string>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sb.Append(matrix[j, i]);
                }

                rows.Add(sb.ToString());
            }
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] - '0' == 0)
                {
                    vectors.Add("0".PadLeft(matrix.GetLength(0), '0'));
                }
                else if (vector[i] - '0' == 1)
                {
                    vectors.Add(rows[i]);
                }
            }

            string vectorResult = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                foreach (var item in vectors)
                {
                    sum += Int32.Parse(item[i].ToString());
                }

                if (sum % 2 == 1)
                    vectorResult += "1";
                if (sum % 2 == 0)
                    vectorResult += "0";
            }
            return vectorResult;
        }
    }
}
