﻿namespace ErrorCorrectingCode
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
            this.sendButton = new System.Windows.Forms.Button();
            this.probabilityTrackBar = new System.Windows.Forms.TrackBar();
            this.probabilityValue = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.sendFindingErrorsButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.textTabPage = new System.Windows.Forms.TabPage();
            this.imageTabPage = new System.Windows.Forms.TabPage();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.sendImageButton = new System.Windows.Forms.Button();
            this.decodedPictureBox = new System.Windows.Forms.PictureBox();
            this.encodedPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageProbabilityValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageProbabilityTrackBar = new System.Windows.Forms.TrackBar();
            this.decodedPictureBoxWithCorrecting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            this.textTabPage.SuspendLayout();
            this.imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProbabilityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBoxWithCorrecting)).BeginInit();
            this.SuspendLayout();
            // 
            // encodeTextBox
            // 
            this.encodeTextBox.Location = new System.Drawing.Point(19, 33);
            this.encodeTextBox.Name = "encodeTextBox";
            this.encodeTextBox.Size = new System.Drawing.Size(779, 531);
            this.encodeTextBox.TabIndex = 0;
            this.encodeTextBox.Text = "";
            // 
            // decodeTextBox
            // 
            this.decodeTextBox.Location = new System.Drawing.Point(1252, 36);
            this.decodeTextBox.Name = "decodeTextBox";
            this.decodeTextBox.Size = new System.Drawing.Size(832, 528);
            this.decodeTextBox.TabIndex = 1;
            this.decodeTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(870, 220);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(337, 159);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // probabilityTrackBar
            // 
            this.probabilityTrackBar.Location = new System.Drawing.Point(870, 84);
            this.probabilityTrackBar.Maximum = 100;
            this.probabilityTrackBar.Name = "probabilityTrackBar";
            this.probabilityTrackBar.Size = new System.Drawing.Size(272, 101);
            this.probabilityTrackBar.TabIndex = 3;
            this.probabilityTrackBar.ValueChanged += new System.EventHandler(this.probabilityTrackBar_ValueChanged);
            // 
            // probabilityValue
            // 
            this.probabilityValue.Location = new System.Drawing.Point(1148, 84);
            this.probabilityValue.Name = "probabilityValue";
            this.probabilityValue.Size = new System.Drawing.Size(59, 35);
            this.probabilityValue.TabIndex = 4;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(865, 33);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(320, 29);
            this.Title.TabIndex = 5;
            this.Title.Text = "Probability of corrupted data:";
            // 
            // sendFindingErrorsButton
            // 
            this.sendFindingErrorsButton.Location = new System.Drawing.Point(870, 405);
            this.sendFindingErrorsButton.Name = "sendFindingErrorsButton";
            this.sendFindingErrorsButton.Size = new System.Drawing.Size(337, 159);
            this.sendFindingErrorsButton.TabIndex = 6;
            this.sendFindingErrorsButton.Text = "Send with error correction";
            this.sendFindingErrorsButton.UseVisualStyleBackColor = true;
            this.sendFindingErrorsButton.Click += new System.EventHandler(this.sendFindingErrorsButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.textTabPage);
            this.tabControl.Controls.Add(this.imageTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(2131, 1209);
            this.tabControl.TabIndex = 7;
            // 
            // textTabPage
            // 
            this.textTabPage.Controls.Add(this.sendFindingErrorsButton);
            this.textTabPage.Controls.Add(this.probabilityValue);
            this.textTabPage.Controls.Add(this.Title);
            this.textTabPage.Controls.Add(this.probabilityTrackBar);
            this.textTabPage.Controls.Add(this.sendButton);
            this.textTabPage.Controls.Add(this.decodeTextBox);
            this.textTabPage.Controls.Add(this.encodeTextBox);
            this.textTabPage.Location = new System.Drawing.Point(10, 47);
            this.textTabPage.Name = "textTabPage";
            this.textTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.textTabPage.Size = new System.Drawing.Size(2111, 594);
            this.textTabPage.TabIndex = 0;
            this.textTabPage.Text = "Text";
            this.textTabPage.UseVisualStyleBackColor = true;
            // 
            // imageTabPage
            // 
            this.imageTabPage.Controls.Add(this.decodedPictureBoxWithCorrecting);
            this.imageTabPage.Controls.Add(this.imageProbabilityValue);
            this.imageTabPage.Controls.Add(this.label1);
            this.imageTabPage.Controls.Add(this.imageProbabilityTrackBar);
            this.imageTabPage.Controls.Add(this.fileNameLabel);
            this.imageTabPage.Controls.Add(this.chooseFileButton);
            this.imageTabPage.Controls.Add(this.sendImageButton);
            this.imageTabPage.Controls.Add(this.decodedPictureBox);
            this.imageTabPage.Controls.Add(this.encodedPictureBox);
            this.imageTabPage.Location = new System.Drawing.Point(10, 47);
            this.imageTabPage.Name = "imageTabPage";
            this.imageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.imageTabPage.Size = new System.Drawing.Size(2111, 1152);
            this.imageTabPage.TabIndex = 1;
            this.imageTabPage.Text = "Image";
            this.imageTabPage.UseVisualStyleBackColor = true;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(886, 225);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 29);
            this.fileNameLabel.TabIndex = 9;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(1153, 225);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(81, 67);
            this.chooseFileButton.TabIndex = 8;
            this.chooseFileButton.Text = "...";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // sendImageButton
            // 
            this.sendImageButton.Location = new System.Drawing.Point(891, 607);
            this.sendImageButton.Name = "sendImageButton";
            this.sendImageButton.Size = new System.Drawing.Size(337, 144);
            this.sendImageButton.TabIndex = 3;
            this.sendImageButton.Text = "Send";
            this.sendImageButton.UseVisualStyleBackColor = true;
            this.sendImageButton.Click += new System.EventHandler(this.sendImageButton_Click);
            // 
            // decodedPictureBox
            // 
            this.decodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.decodedPictureBox.Location = new System.Drawing.Point(1252, 21);
            this.decodedPictureBox.Name = "decodedPictureBox";
            this.decodedPictureBox.Size = new System.Drawing.Size(831, 540);
            this.decodedPictureBox.TabIndex = 1;
            this.decodedPictureBox.TabStop = false;
            // 
            // encodedPictureBox
            // 
            this.encodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.encodedPictureBox.Location = new System.Drawing.Point(28, 317);
            this.encodedPictureBox.Name = "encodedPictureBox";
            this.encodedPictureBox.Size = new System.Drawing.Size(831, 540);
            this.encodedPictureBox.TabIndex = 0;
            this.encodedPictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // imageProbabilityValue
            // 
            this.imageProbabilityValue.Location = new System.Drawing.Point(1153, 430);
            this.imageProbabilityValue.Name = "imageProbabilityValue";
            this.imageProbabilityValue.Size = new System.Drawing.Size(75, 35);
            this.imageProbabilityValue.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Probability of corrupted data:";
            // 
            // imageProbabilityTrackBar
            // 
            this.imageProbabilityTrackBar.Location = new System.Drawing.Point(891, 430);
            this.imageProbabilityTrackBar.Maximum = 100;
            this.imageProbabilityTrackBar.Name = "imageProbabilityTrackBar";
            this.imageProbabilityTrackBar.Size = new System.Drawing.Size(256, 101);
            this.imageProbabilityTrackBar.TabIndex = 10;
            this.imageProbabilityTrackBar.ValueChanged += new System.EventHandler(this.imageProbabilityTrackBar_ValueChanged);
            // 
            // decodedPictureBoxWithCorrecting
            // 
            this.decodedPictureBoxWithCorrecting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.decodedPictureBoxWithCorrecting.Location = new System.Drawing.Point(1252, 584);
            this.decodedPictureBoxWithCorrecting.Name = "decodedPictureBoxWithCorrecting";
            this.decodedPictureBoxWithCorrecting.Size = new System.Drawing.Size(831, 540);
            this.decodedPictureBoxWithCorrecting.TabIndex = 13;
            this.decodedPictureBoxWithCorrecting.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2178, 1258);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "Error Correcting by Emilis Ruzveltas";
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.textTabPage.ResumeLayout(false);
            this.textTabPage.PerformLayout();
            this.imageTabPage.ResumeLayout(false);
            this.imageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProbabilityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBoxWithCorrecting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox encodeTextBox;
        private System.Windows.Forms.RichTextBox decodeTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TrackBar probabilityTrackBar;
        private System.Windows.Forms.TextBox probabilityValue;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button sendFindingErrorsButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage textTabPage;
        private System.Windows.Forms.TabPage imageTabPage;
        private System.Windows.Forms.Button sendImageButton;
        private System.Windows.Forms.PictureBox decodedPictureBox;
        private System.Windows.Forms.PictureBox encodedPictureBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox imageProbabilityValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar imageProbabilityTrackBar;
        private System.Windows.Forms.PictureBox decodedPictureBoxWithCorrecting;
    }
}

