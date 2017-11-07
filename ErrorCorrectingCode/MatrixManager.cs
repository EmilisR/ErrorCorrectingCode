using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCorrectingCode
{
    public class MatrixManager
    {
        public byte[,] GenerateMatrix(int height, int width)
        {
            Random random = new Random();
            bool validated = false;
            byte[,] matrix = new byte[height, width];

            #region Fill diagonal with 1's
            for (int i = 0; i < height; i++)
            {
                matrix[i, i] = 1;
            }
            #endregion
            #region Fill other cells with random data
            while (!validated)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = height; j < width; j++)
                    {
                        if (random.Next(0, 100000) < 50000)
                        {
                            matrix[i, j] = 0;
                        }
                        else
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }
                if (!IsValidMatrix(matrix))
                    continue;
                else
                    validated = true;
            }
            #endregion
            return matrix;
        }

        public bool IsValidMatrix(byte[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            HashSet<string> hashSetRows = new HashSet<string>();
            HashSet<string> hashSetColumns = new HashSet<string>();
            for (int i = 0, j = 0; i < height; i++, j++)
            {
                var str = new string(GetRow(matrix, j).OfType<byte>().Select(x => x.ToString()[0]).ToArray());
                var partOfStr = str.Substring(height, width - height);
                hashSetRows.Add(partOfStr);
            }
            /*for (int i = 0, j = 0; i < width; i++, j++)
            {
                var str = new string(GetColumn(matrix, j).OfType<byte>().Select(x => x.ToString()[0]).ToArray());
                hashSetColumns.Add(str);
            }*/
            if (hashSetRows.Count == height/* && hashSetColumns.Count == width*/)
                return true;
            else
                return false;
        }

        public Dictionary<byte[], byte[]> GetEncodingTable(byte[,] matrix, int heigth)
        {
            var dict = new Dictionary<byte[], byte[]>();

            for (int i = 0; i < Math.Pow(2, heigth); i++)
            {
                var vector = Convert.ToString(i, 2).PadLeft(heigth, '0').Select(x => (byte)char.GetNumericValue(x)).ToArray();
                var encodedVector = MultiplyMatrixAndVector(TransposeMatrix(matrix), vector);
                if (!dict.Keys.Any(x => x.SequenceEqual(vector)))
                {
                    dict.Add(vector, encodedVector);
                }
            }

            return dict;
        }

        public byte[,] DataGridViewTableToMatrix(DataGridView grid)
        {
            byte[,] matrix = new byte[grid.Rows.Count, grid.Columns.Count];

            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    matrix[row.Index, column.Index] = Convert.ToByte(grid.Rows[row.Index].Cells[column.Index].Value);
                }
            }

            return matrix;
        }

        public int GetWeightOfVector(byte[] vector)
        {
            return vector.Where(x => x == 1).Count();
        }

        public byte[] GetRow(byte[,] matrix, int row)
        {
            var width = matrix.GetLength(1);
            var height = matrix.GetLength(0);
            var returnRow = new byte[width];
            for (var i = 0; i < width; i++)
                returnRow[i] = matrix[row, i];

            return returnRow;
        }

        public byte[] AddVector(byte[] vector1, byte[] vector2)
        {
            var result = new byte[vector1.Length];

            for (int i = 0; i < vector1.Length; i++)
            {
                if (vector1[i] + vector2[i] == 1)
                    result[i] = 1;
                else result[i] = 0;
            }

            return result;
        }

        public byte[] MultiplyMatrixAndVector(byte[,] matrix, byte[] vector)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            int sum = 0;
            var result = new byte[height];

            for (int i = 0; i < height; i++)
            {
                sum = 0;
                for (int j = 0; j < width; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }
                result[i] = (byte)(sum % 2);
            }

            return result;
        }

        public byte[,] GenerateParityCheckFromGeneratingMatrix(byte[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            var rightPartOfMatrix = new byte[height, width - height];

            for (int i = 0; i < height; i++)
            {
                for (int j = height, m = 0; j < width; j++, m++)
                {
                    rightPartOfMatrix[i, m] = matrix[i, j];
                }
            }

            var transposed = TransposeMatrix(rightPartOfMatrix);
            var rightPartOfParityMatrix = new byte[width - height, width - height];

            for (int i = 0; i < rightPartOfParityMatrix.GetLength(0); i++)
            {
                rightPartOfParityMatrix[i, i] = 1;
            }

            var parity = new byte[transposed.GetLength(0), transposed.GetLength(1) + rightPartOfParityMatrix.GetLength(1)];

            for (int i = 0; i < parity.GetLength(0); i++)
            {
                for (int j = 0; j < parity.GetLength(1); j++)
                {
                    if (j < transposed.GetLength(1))
                        parity[i, j] = transposed[i, j];
                    else
                        parity[i, j] = rightPartOfParityMatrix[i, j - transposed.GetLength(1)];
                }
            }

            return parity;
        }

        public byte[,] TransposeMatrix(byte[,] matrix)
        {
            int width = matrix.GetLength(0);
            int heigth = matrix.GetLength(1);

            byte[,] transposed = new byte[heigth, width];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }

            return transposed;
        }

        public byte[,] SetMatrix(DataGridView data)
        {
            byte[,] matrix = new byte[data.RowCount, data.ColumnCount];

            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    var bit = byte.Parse(data[j, i].Value.ToString());
                    matrix[i, j] = bit;
                }
            }
            return matrix;
        }

        public byte[] GetSindrome(byte[,] parityMatrix, byte[] vector)
        {
            return MultiplyMatrixAndVector(parityMatrix, vector);
        }
    }
}
