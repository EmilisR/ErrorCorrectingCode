namespace ErrorCorrectingCode
{
    partial class MainWindow
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
            this.encodeTextBox = new System.Windows.Forms.RichTextBox();
            this.decodeTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.textTabPage = new System.Windows.Forms.TabPage();
            this.noDecodeTextBox = new System.Windows.Forms.RichTextBox();
            this.imageTabPage = new System.Windows.Forms.TabPage();
            this.stopwatch = new System.Windows.Forms.Label();
            this.correctedErrorsCount = new System.Windows.Forms.Label();
            this.withCorrectionErrorsCount = new System.Windows.Forms.Label();
            this.withoutCorrectionErrorsCount = new System.Windows.Forms.Label();
            this.bitsCount = new System.Windows.Forms.Label();
            this.decodedPictureBoxWithCorrecting = new System.Windows.Forms.PictureBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.decodedPictureBox = new System.Windows.Forms.PictureBox();
            this.encodedPictureBox = new System.Windows.Forms.PictureBox();
            this.viewMatrixButton = new System.Windows.Forms.Button();
            this.generateMatrixButton = new System.Windows.Forms.Button();
            this.probabilityValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.probabilityTrackBar = new System.Windows.Forms.TrackBar();
            this.sendImageButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textStopwatch = new System.Windows.Forms.Label();
            this.textCorrectedErrorsCount = new System.Windows.Forms.Label();
            this.textWithCorrectionErrorsCount = new System.Windows.Forms.Label();
            this.textWithoutCorrectionErrorsCount = new System.Windows.Forms.Label();
            this.textBitCount = new System.Windows.Forms.Label();
            this.vectorTabPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.textTabPage.SuspendLayout();
            this.imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBoxWithCorrecting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // encodeTextBox
            // 
            this.encodeTextBox.Location = new System.Drawing.Point(33, 676);
            this.encodeTextBox.Name = "encodeTextBox";
            this.encodeTextBox.Size = new System.Drawing.Size(779, 531);
            this.encodeTextBox.TabIndex = 0;
            this.encodeTextBox.Text = "";
            // 
            // decodeTextBox
            // 
            this.decodeTextBox.Location = new System.Drawing.Point(838, 676);
            this.decodeTextBox.Name = "decodeTextBox";
            this.decodeTextBox.Size = new System.Drawing.Size(832, 528);
            this.decodeTextBox.TabIndex = 1;
            this.decodeTextBox.Text = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.textTabPage);
            this.tabControl.Controls.Add(this.imageTabPage);
            this.tabControl.Controls.Add(this.vectorTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1783, 1277);
            this.tabControl.TabIndex = 7;
            // 
            // textTabPage
            // 
            this.textTabPage.Controls.Add(this.textBitCount);
            this.textTabPage.Controls.Add(this.textWithoutCorrectionErrorsCount);
            this.textTabPage.Controls.Add(this.textWithCorrectionErrorsCount);
            this.textTabPage.Controls.Add(this.textCorrectedErrorsCount);
            this.textTabPage.Controls.Add(this.textStopwatch);
            this.textTabPage.Controls.Add(this.label4);
            this.textTabPage.Controls.Add(this.label3);
            this.textTabPage.Controls.Add(this.label2);
            this.textTabPage.Controls.Add(this.noDecodeTextBox);
            this.textTabPage.Controls.Add(this.decodeTextBox);
            this.textTabPage.Controls.Add(this.encodeTextBox);
            this.textTabPage.Location = new System.Drawing.Point(10, 47);
            this.textTabPage.Name = "textTabPage";
            this.textTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.textTabPage.Size = new System.Drawing.Size(1763, 1220);
            this.textTabPage.TabIndex = 0;
            this.textTabPage.Text = "Tekstas";
            this.textTabPage.UseVisualStyleBackColor = true;
            // 
            // noDecodeTextBox
            // 
            this.noDecodeTextBox.Location = new System.Drawing.Point(838, 63);
            this.noDecodeTextBox.Name = "noDecodeTextBox";
            this.noDecodeTextBox.Size = new System.Drawing.Size(832, 528);
            this.noDecodeTextBox.TabIndex = 2;
            this.noDecodeTextBox.Text = "";
            // 
            // imageTabPage
            // 
            this.imageTabPage.Controls.Add(this.label7);
            this.imageTabPage.Controls.Add(this.label6);
            this.imageTabPage.Controls.Add(this.label5);
            this.imageTabPage.Controls.Add(this.stopwatch);
            this.imageTabPage.Controls.Add(this.correctedErrorsCount);
            this.imageTabPage.Controls.Add(this.withCorrectionErrorsCount);
            this.imageTabPage.Controls.Add(this.withoutCorrectionErrorsCount);
            this.imageTabPage.Controls.Add(this.bitsCount);
            this.imageTabPage.Controls.Add(this.decodedPictureBoxWithCorrecting);
            this.imageTabPage.Controls.Add(this.fileNameLabel);
            this.imageTabPage.Controls.Add(this.chooseFileButton);
            this.imageTabPage.Controls.Add(this.decodedPictureBox);
            this.imageTabPage.Controls.Add(this.encodedPictureBox);
            this.imageTabPage.Location = new System.Drawing.Point(10, 47);
            this.imageTabPage.Name = "imageTabPage";
            this.imageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.imageTabPage.Size = new System.Drawing.Size(1763, 1220);
            this.imageTabPage.TabIndex = 1;
            this.imageTabPage.Text = "Paveiksliukas";
            this.imageTabPage.UseVisualStyleBackColor = true;
            // 
            // stopwatch
            // 
            this.stopwatch.AutoSize = true;
            this.stopwatch.Location = new System.Drawing.Point(31, 502);
            this.stopwatch.Name = "stopwatch";
            this.stopwatch.Size = new System.Drawing.Size(0, 29);
            this.stopwatch.TabIndex = 22;
            // 
            // correctedErrorsCount
            // 
            this.correctedErrorsCount.AutoSize = true;
            this.correctedErrorsCount.Location = new System.Drawing.Point(31, 449);
            this.correctedErrorsCount.Name = "correctedErrorsCount";
            this.correctedErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.correctedErrorsCount.TabIndex = 21;
            // 
            // withCorrectionErrorsCount
            // 
            this.withCorrectionErrorsCount.AutoSize = true;
            this.withCorrectionErrorsCount.Location = new System.Drawing.Point(31, 399);
            this.withCorrectionErrorsCount.Name = "withCorrectionErrorsCount";
            this.withCorrectionErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.withCorrectionErrorsCount.TabIndex = 20;
            // 
            // withoutCorrectionErrorsCount
            // 
            this.withoutCorrectionErrorsCount.AutoSize = true;
            this.withoutCorrectionErrorsCount.Location = new System.Drawing.Point(31, 350);
            this.withoutCorrectionErrorsCount.Name = "withoutCorrectionErrorsCount";
            this.withoutCorrectionErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.withoutCorrectionErrorsCount.TabIndex = 19;
            // 
            // bitsCount
            // 
            this.bitsCount.AutoSize = true;
            this.bitsCount.Location = new System.Drawing.Point(31, 301);
            this.bitsCount.Name = "bitsCount";
            this.bitsCount.Size = new System.Drawing.Size(0, 29);
            this.bitsCount.TabIndex = 18;
            // 
            // decodedPictureBoxWithCorrecting
            // 
            this.decodedPictureBoxWithCorrecting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.decodedPictureBoxWithCorrecting.Location = new System.Drawing.Point(891, 662);
            this.decodedPictureBoxWithCorrecting.Name = "decodedPictureBoxWithCorrecting";
            this.decodedPictureBoxWithCorrecting.Size = new System.Drawing.Size(831, 540);
            this.decodedPictureBoxWithCorrecting.TabIndex = 13;
            this.decodedPictureBoxWithCorrecting.TabStop = false;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(362, 206);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 29);
            this.fileNameLabel.TabIndex = 9;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(36, 187);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(296, 67);
            this.chooseFileButton.TabIndex = 8;
            this.chooseFileButton.Text = "Pridėti paveiksliuką";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // decodedPictureBox
            // 
            this.decodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.decodedPictureBox.Location = new System.Drawing.Point(891, 64);
            this.decodedPictureBox.Name = "decodedPictureBox";
            this.decodedPictureBox.Size = new System.Drawing.Size(831, 540);
            this.decodedPictureBox.TabIndex = 1;
            this.decodedPictureBox.TabStop = false;
            // 
            // encodedPictureBox
            // 
            this.encodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.encodedPictureBox.Location = new System.Drawing.Point(36, 662);
            this.encodedPictureBox.Name = "encodedPictureBox";
            this.encodedPictureBox.Size = new System.Drawing.Size(831, 540);
            this.encodedPictureBox.TabIndex = 0;
            this.encodedPictureBox.TabStop = false;
            // 
            // viewMatrixButton
            // 
            this.viewMatrixButton.Location = new System.Drawing.Point(1803, 227);
            this.viewMatrixButton.Name = "viewMatrixButton";
            this.viewMatrixButton.Size = new System.Drawing.Size(294, 125);
            this.viewMatrixButton.TabIndex = 16;
            this.viewMatrixButton.Text = "Peržiūrėti generuojančią matricą";
            this.viewMatrixButton.UseVisualStyleBackColor = true;
            this.viewMatrixButton.Click += new System.EventHandler(this.viewMatrixButton_Click);
            // 
            // generateMatrixButton
            // 
            this.generateMatrixButton.Location = new System.Drawing.Point(1803, 69);
            this.generateMatrixButton.Name = "generateMatrixButton";
            this.generateMatrixButton.Size = new System.Drawing.Size(292, 125);
            this.generateMatrixButton.TabIndex = 15;
            this.generateMatrixButton.Text = "Sugeneruoti generuojančią matricą";
            this.generateMatrixButton.UseVisualStyleBackColor = true;
            this.generateMatrixButton.Click += new System.EventHandler(this.generateMatrixButton_Click);
            // 
            // probabilityValue
            // 
            this.probabilityValue.Location = new System.Drawing.Point(1964, 492);
            this.probabilityValue.Name = "probabilityValue";
            this.probabilityValue.Size = new System.Drawing.Size(110, 35);
            this.probabilityValue.TabIndex = 11;
            this.probabilityValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imageProbabilityValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1801, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kanalo nepatikimumo %";
            // 
            // probabilityTrackBar
            // 
            this.probabilityTrackBar.Location = new System.Drawing.Point(1822, 546);
            this.probabilityTrackBar.Maximum = 10000;
            this.probabilityTrackBar.Name = "probabilityTrackBar";
            this.probabilityTrackBar.Size = new System.Drawing.Size(256, 101);
            this.probabilityTrackBar.TabIndex = 10;
            this.probabilityTrackBar.ValueChanged += new System.EventHandler(this.imageProbabilityTrackBar_ValueChanged);
            // 
            // sendImageButton
            // 
            this.sendImageButton.Location = new System.Drawing.Point(1805, 653);
            this.sendImageButton.Name = "sendImageButton";
            this.sendImageButton.Size = new System.Drawing.Size(290, 144);
            this.sendImageButton.TabIndex = 3;
            this.sendImageButton.Text = "Apdoroti";
            this.sendImageButton.UseVisualStyleBackColor = true;
            this.sendImageButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(833, 625);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Su klaidų taisymu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(833, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Be klaidų taisymo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 625);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pradinis pranešimas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Pradinis paveiksliukas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(886, 615);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Su klaidų taisymu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(886, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Be klaidų taisymo";
            // 
            // textStopwatch
            // 
            this.textStopwatch.AutoSize = true;
            this.textStopwatch.Location = new System.Drawing.Point(28, 541);
            this.textStopwatch.Name = "textStopwatch";
            this.textStopwatch.Size = new System.Drawing.Size(0, 29);
            this.textStopwatch.TabIndex = 6;
            // 
            // textCorrectedErrorsCount
            // 
            this.textCorrectedErrorsCount.AutoSize = true;
            this.textCorrectedErrorsCount.Location = new System.Drawing.Point(28, 492);
            this.textCorrectedErrorsCount.Name = "textCorrectedErrorsCount";
            this.textCorrectedErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.textCorrectedErrorsCount.TabIndex = 7;
            // 
            // textWithCorrectionErrorsCount
            // 
            this.textWithCorrectionErrorsCount.AutoSize = true;
            this.textWithCorrectionErrorsCount.Location = new System.Drawing.Point(28, 446);
            this.textWithCorrectionErrorsCount.Name = "textWithCorrectionErrorsCount";
            this.textWithCorrectionErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.textWithCorrectionErrorsCount.TabIndex = 8;
            // 
            // textWithoutCorrectionErrorsCount
            // 
            this.textWithoutCorrectionErrorsCount.AutoSize = true;
            this.textWithoutCorrectionErrorsCount.Location = new System.Drawing.Point(28, 398);
            this.textWithoutCorrectionErrorsCount.Name = "textWithoutCorrectionErrorsCount";
            this.textWithoutCorrectionErrorsCount.Size = new System.Drawing.Size(0, 29);
            this.textWithoutCorrectionErrorsCount.TabIndex = 9;
            // 
            // textBitCount
            // 
            this.textBitCount.AutoSize = true;
            this.textBitCount.Location = new System.Drawing.Point(28, 352);
            this.textBitCount.Name = "textBitCount";
            this.textBitCount.Size = new System.Drawing.Size(0, 29);
            this.textBitCount.TabIndex = 10;
            // 
            // vectorTabPage
            // 
            this.vectorTabPage.Location = new System.Drawing.Point(10, 47);
            this.vectorTabPage.Name = "vectorTabPage";
            this.vectorTabPage.Size = new System.Drawing.Size(1763, 1220);
            this.vectorTabPage.TabIndex = 2;
            this.vectorTabPage.Text = "Vektorius";
            this.vectorTabPage.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2138, 1321);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.sendImageButton);
            this.Controls.Add(this.probabilityTrackBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.probabilityValue);
            this.Controls.Add(this.viewMatrixButton);
            this.Controls.Add(this.generateMatrixButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "Klaidų taisymas [Emilis Ruzveltas]";
            this.tabControl.ResumeLayout(false);
            this.textTabPage.ResumeLayout(false);
            this.textTabPage.PerformLayout();
            this.imageTabPage.ResumeLayout(false);
            this.imageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBoxWithCorrecting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox encodeTextBox;
        private System.Windows.Forms.RichTextBox decodeTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage textTabPage;
        private System.Windows.Forms.TabPage imageTabPage;
        private System.Windows.Forms.Button sendImageButton;
        private System.Windows.Forms.PictureBox decodedPictureBox;
        private System.Windows.Forms.PictureBox encodedPictureBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox probabilityValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar probabilityTrackBar;
        private System.Windows.Forms.PictureBox decodedPictureBoxWithCorrecting;
        private System.Windows.Forms.Button viewMatrixButton;
        private System.Windows.Forms.Button generateMatrixButton;
        private System.Windows.Forms.Label bitsCount;
        private System.Windows.Forms.Label withCorrectionErrorsCount;
        private System.Windows.Forms.Label withoutCorrectionErrorsCount;
        private System.Windows.Forms.Label correctedErrorsCount;
        private System.Windows.Forms.Label stopwatch;
        private System.Windows.Forms.RichTextBox noDecodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label textBitCount;
        private System.Windows.Forms.Label textWithoutCorrectionErrorsCount;
        private System.Windows.Forms.Label textWithCorrectionErrorsCount;
        private System.Windows.Forms.Label textCorrectedErrorsCount;
        private System.Windows.Forms.Label textStopwatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage vectorTabPage;
    }
}

