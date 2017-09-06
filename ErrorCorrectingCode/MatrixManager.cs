using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCorrectingCode
{
    public class MatrixManager
    {
        public byte[,] GenerateMatrix(int width, int height)
        {
            Random random = new Random();
            byte[,] matrix = new byte[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
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
            return matrix;
        }

        public byte[,] SetMatrix(DataGridView data)
        {
            byte[,] matrix = new byte[data.ColumnCount, data.RowCount];

            for (int i = 0; i < data.ColumnCount; i++)
            {
                for (int j = 0; j < data.RowCount; j++)
                {
                    matrix[i, j] = byte.Parse(data[i, j].Value.ToString());
                }
            }
            return matrix;
        }
    }
}
