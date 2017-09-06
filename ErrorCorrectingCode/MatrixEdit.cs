using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCorrectingCode
{
    public partial class MatrixEdit : Form
    {
        public byte[,] matrix;
        public bool generate = false;
        public bool viewMode = false;

        public MatrixEdit()
        {
            InitializeComponent();
        }

        public MatrixEdit(byte[,] matrixArray) : this()
        {
            changeMatrixSizeButton.Visible = false;
            dimensionLabel.Visible = false;
            dimensionMaskedTextBox.Visible = false;
            codeLengthLabel.Visible = false;
            codeLengthMaskedTextBox.Visible = false;
            saveMatrixButton.Visible = false;
            matrixTable.RowCount = matrixArray.GetLength(1);
            matrixTable.ColumnCount = matrixArray.GetLength(0);
            BindMatrixArrayToTable(matrixArray, matrixTable.ColumnCount, matrixTable.RowCount);
            foreach (DataGridViewRow row in matrixTable.Rows)
            {
                row.Height = matrixTable.Height / matrixTable.RowCount - 1;
            }

            foreach (DataGridViewColumn column in matrixTable.Columns)
            {
                column.Width = matrixTable.Width / matrixTable.ColumnCount - 1;
            }
            matrixTable.Enabled = false;
        }

        private void changeMatrixSizeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(codeLengthMaskedTextBox.Text, out int width) &&
                int.TryParse(dimensionMaskedTextBox.Text, out int heigth) &&
                width > 0 &&
                heigth > 0)
            {
                matrixTable.RowCount = Convert.ToInt32(heigth);
                matrixTable.ColumnCount = Convert.ToInt32(width);

                foreach (DataGridViewRow row in matrixTable.Rows)
                {
                    row.Height = matrixTable.Height / heigth - 1;
                }

                foreach (DataGridViewColumn column in matrixTable.Columns)
                {
                    column.Width = matrixTable.Width / width - 1;
                }

                if (generate)
                {
                    byte[,] matrixArray = new MatrixManager().GenerateMatrix(width, heigth);
                    BindMatrixArrayToTable(matrixArray, width, heigth);
                }
                else
                {
                    MessageBox.Show("Klaidingai įvesti matricos dydžiai", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindMatrixArrayToTable(byte[,] array, int width, int heigth)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    matrixTable[i, j].Value = array[i, j].ToString();
                }
            }
        }

        private void SaveMatrixButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in matrixTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    int result = 2;
                    var valid = cell.Value != null ? int.TryParse(cell.Value.ToString(), out result) : false;
                    if (valid)
                    {
                        if (result != 0 && result != 1)
                        {
                            cell.Style.BackColor = Color.Red;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        cell.Style.BackColor = Color.Red;
                    }

                    matrixTable.ClearSelection();
                }
            }

            if (matrixTable.Rows.Cast<DataGridViewRow>().Any(x => x.Cells.Cast<DataGridViewCell>().Where(y => y.Style.BackColor == Color.Red).Count() > 0))
            {
                MessageBox.Show("Klaidingai įvesti matricos duomenys", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.matrix = new MatrixManager().SetMatrix(matrixTable);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void MatrixEdit_Load(object sender, EventArgs e)
        {
            matrixTable.ClearSelection();
        }
    }
}
