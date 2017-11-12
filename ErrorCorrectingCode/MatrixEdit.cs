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

    /// <summary>
    /// 
    /// </summary>
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
            matrixTable.RowCount = matrixArray.GetLength(0);
            matrixTable.ColumnCount = matrixArray.GetLength(1);
            BindMatrixArrayToTable(matrixArray, matrixTable.RowCount, matrixTable.ColumnCount);
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
                if (width < heigth)
                {
                    MessageBox.Show("Matricos dimensija negali būti didesnė nei kodo ilgis", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Math.Pow(2, width - heigth) < heigth)
                {
                    MessageBox.Show("Matricos parametrai netinkami generuoti matricą", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                    byte[,] matrixArray = new MatrixManager().GenerateMatrix(heigth, width);
                    BindMatrixArrayToTable(matrixArray, heigth, width);
                }
                else if (matrixTable == null)
                {
                    MessageBox.Show("Klaidingai įvesti matricos dydžiai", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindMatrixArrayToTable(byte[,] array, int heigth, int width)
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrixTable[j, i].Value = array[i, j].ToString();
                }
            }
        }

        private void SaveMatrixButton_Click(object sender, EventArgs e)
        {
            var manager = new MatrixManager();
            if (!manager.IsValidMatrix(manager.DataGridViewTableToMatrix(matrixTable)))
            {
                MessageBox.Show("Klaidingai įvesti matricos dydžiai", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                this.matrix = new MatrixManager().DataGridViewTableToMatrix(matrixTable);
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
