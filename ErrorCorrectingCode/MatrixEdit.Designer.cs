namespace ErrorCorrectingCode
{
    partial class MatrixEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.codeLengthMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.dimensionMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.codeLengthLabel = new System.Windows.Forms.Label();
            this.dimensionLabel = new System.Windows.Forms.Label();
            this.changeMatrixSizeButton = new System.Windows.Forms.Button();
            this.saveMatrixButton = new System.Windows.Forms.Button();
            this.matrixTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.matrixTable)).BeginInit();
            this.SuspendLayout();
            // 
            // codeLengthMaskedTextBox
            // 
            this.codeLengthMaskedTextBox.Location = new System.Drawing.Point(168, 78);
            this.codeLengthMaskedTextBox.Name = "codeLengthMaskedTextBox";
            this.codeLengthMaskedTextBox.Size = new System.Drawing.Size(100, 35);
            this.codeLengthMaskedTextBox.TabIndex = 0;
            // 
            // dimensionMaskedTextBox
            // 
            this.dimensionMaskedTextBox.Location = new System.Drawing.Point(490, 78);
            this.dimensionMaskedTextBox.Name = "dimensionMaskedTextBox";
            this.dimensionMaskedTextBox.Size = new System.Drawing.Size(100, 35);
            this.dimensionMaskedTextBox.TabIndex = 1;
            // 
            // codeLengthLabel
            // 
            this.codeLengthLabel.AutoSize = true;
            this.codeLengthLabel.Location = new System.Drawing.Point(35, 84);
            this.codeLengthLabel.Name = "codeLengthLabel";
            this.codeLengthLabel.Size = new System.Drawing.Size(127, 29);
            this.codeLengthLabel.TabIndex = 2;
            this.codeLengthLabel.Text = "Kodo ilgis:";
            // 
            // dimensionLabel
            // 
            this.dimensionLabel.AutoSize = true;
            this.dimensionLabel.Location = new System.Drawing.Point(358, 84);
            this.dimensionLabel.Name = "dimensionLabel";
            this.dimensionLabel.Size = new System.Drawing.Size(126, 29);
            this.dimensionLabel.TabIndex = 3;
            this.dimensionLabel.Text = "Dimensija:";
            // 
            // changeMatrixSizeButton
            // 
            this.changeMatrixSizeButton.Location = new System.Drawing.Point(650, 70);
            this.changeMatrixSizeButton.Name = "changeMatrixSizeButton";
            this.changeMatrixSizeButton.Size = new System.Drawing.Size(178, 56);
            this.changeMatrixSizeButton.TabIndex = 4;
            this.changeMatrixSizeButton.Text = "Pakeisti dydį";
            this.changeMatrixSizeButton.UseVisualStyleBackColor = true;
            this.changeMatrixSizeButton.Click += new System.EventHandler(this.changeMatrixSizeButton_Click);
            // 
            // saveMatrixButton
            // 
            this.saveMatrixButton.Location = new System.Drawing.Point(333, 725);
            this.saveMatrixButton.Name = "saveMatrixButton";
            this.saveMatrixButton.Size = new System.Drawing.Size(257, 106);
            this.saveMatrixButton.TabIndex = 6;
            this.saveMatrixButton.Text = "Išsaugoti";
            this.saveMatrixButton.UseVisualStyleBackColor = true;
            this.saveMatrixButton.Click += new System.EventHandler(this.SaveMatrixButton_Click);
            // 
            // matrixTable
            // 
            this.matrixTable.AllowUserToAddRows = false;
            this.matrixTable.AllowUserToDeleteRows = false;
            this.matrixTable.AllowUserToResizeColumns = false;
            this.matrixTable.AllowUserToResizeRows = false;
            this.matrixTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.matrixTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixTable.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.matrixTable.Location = new System.Drawing.Point(57, 150);
            this.matrixTable.MultiSelect = false;
            this.matrixTable.Name = "matrixTable";
            this.matrixTable.RowHeadersVisible = false;
            this.matrixTable.RowTemplate.Height = 37;
            this.matrixTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.matrixTable.Size = new System.Drawing.Size(788, 556);
            this.matrixTable.TabIndex = 7;
            // 
            // MatrixEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 908);
            this.Controls.Add(this.matrixTable);
            this.Controls.Add(this.saveMatrixButton);
            this.Controls.Add(this.changeMatrixSizeButton);
            this.Controls.Add(this.dimensionLabel);
            this.Controls.Add(this.codeLengthLabel);
            this.Controls.Add(this.dimensionMaskedTextBox);
            this.Controls.Add(this.codeLengthMaskedTextBox);
            this.Name = "MatrixEdit";
            this.Text = "Generuojanti matrica";
            this.Load += new System.EventHandler(this.MatrixEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matrixTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox codeLengthMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox dimensionMaskedTextBox;
        private System.Windows.Forms.Label codeLengthLabel;
        private System.Windows.Forms.Label dimensionLabel;
        private System.Windows.Forms.Button changeMatrixSizeButton;
        private System.Windows.Forms.Button saveMatrixButton;
        private System.Windows.Forms.DataGridView matrixTable;
    }
}