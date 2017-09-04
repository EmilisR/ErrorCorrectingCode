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
            this.sendButton = new System.Windows.Forms.Button();
            this.probabilityTrackBar = new System.Windows.Forms.TrackBar();
            this.probabilityValue = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.sendFindingErrorsButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.textTabPage = new System.Windows.Forms.TabPage();
            this.imageTabPage = new System.Windows.Forms.TabPage();
            this.encodedPictureBox = new System.Windows.Forms.PictureBox();
            this.decodedPictureBox = new System.Windows.Forms.PictureBox();
            this.sendImageButton = new System.Windows.Forms.Button();
            this.sendImageWithErrorFindingButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            this.textTabPage.SuspendLayout();
            this.imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // encodeTextBox
            // 
            this.encodeTextBox.Location = new System.Drawing.Point(19, 33);
            this.encodeTextBox.Name = "encodeTextBox";
            this.encodeTextBox.Size = new System.Drawing.Size(482, 531);
            this.encodeTextBox.TabIndex = 0;
            this.encodeTextBox.Text = "";
            // 
            // decodeTextBox
            // 
            this.decodeTextBox.Location = new System.Drawing.Point(1046, 36);
            this.decodeTextBox.Name = "decodeTextBox";
            this.decodeTextBox.Size = new System.Drawing.Size(443, 528);
            this.decodeTextBox.TabIndex = 1;
            this.decodeTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(609, 219);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(337, 159);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // probabilityTrackBar
            // 
            this.probabilityTrackBar.Location = new System.Drawing.Point(535, 84);
            this.probabilityTrackBar.Maximum = 100;
            this.probabilityTrackBar.Name = "probabilityTrackBar";
            this.probabilityTrackBar.Size = new System.Drawing.Size(337, 101);
            this.probabilityTrackBar.TabIndex = 3;
            this.probabilityTrackBar.ValueChanged += new System.EventHandler(this.probabilityTrackBar_ValueChanged);
            // 
            // probabilityValue
            // 
            this.probabilityValue.Location = new System.Drawing.Point(901, 84);
            this.probabilityValue.Name = "probabilityValue";
            this.probabilityValue.Size = new System.Drawing.Size(100, 35);
            this.probabilityValue.TabIndex = 4;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(530, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(320, 29);
            this.Title.TabIndex = 5;
            this.Title.Text = "Probability of corrupted data:";
            // 
            // sendFindingErrorsButton
            // 
            this.sendFindingErrorsButton.Location = new System.Drawing.Point(609, 405);
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
            this.tabControl.Size = new System.Drawing.Size(1550, 651);
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
            this.textTabPage.Size = new System.Drawing.Size(1530, 594);
            this.textTabPage.TabIndex = 0;
            this.textTabPage.Text = "Text";
            this.textTabPage.UseVisualStyleBackColor = true;
            // 
            // imageTabPage
            // 
            this.imageTabPage.Controls.Add(this.fileNameLabel);
            this.imageTabPage.Controls.Add(this.chooseFileButton);
            this.imageTabPage.Controls.Add(this.sendImageWithErrorFindingButton);
            this.imageTabPage.Controls.Add(this.sendImageButton);
            this.imageTabPage.Controls.Add(this.decodedPictureBox);
            this.imageTabPage.Controls.Add(this.encodedPictureBox);
            this.imageTabPage.Location = new System.Drawing.Point(10, 47);
            this.imageTabPage.Name = "imageTabPage";
            this.imageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.imageTabPage.Size = new System.Drawing.Size(1530, 594);
            this.imageTabPage.TabIndex = 1;
            this.imageTabPage.Text = "Image";
            this.imageTabPage.UseVisualStyleBackColor = true;
            // 
            // encodedPictureBox
            // 
            this.encodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.encodedPictureBox.Location = new System.Drawing.Point(18, 21);
            this.encodedPictureBox.Name = "encodedPictureBox";
            this.encodedPictureBox.Size = new System.Drawing.Size(518, 540);
            this.encodedPictureBox.TabIndex = 0;
            this.encodedPictureBox.TabStop = false;
            // 
            // decodedPictureBox
            // 
            this.decodedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.decodedPictureBox.Location = new System.Drawing.Point(994, 21);
            this.decodedPictureBox.Name = "decodedPictureBox";
            this.decodedPictureBox.Size = new System.Drawing.Size(518, 540);
            this.decodedPictureBox.TabIndex = 1;
            this.decodedPictureBox.TabStop = false;
            // 
            // sendImageButton
            // 
            this.sendImageButton.Location = new System.Drawing.Point(594, 183);
            this.sendImageButton.Name = "sendImageButton";
            this.sendImageButton.Size = new System.Drawing.Size(337, 159);
            this.sendImageButton.TabIndex = 3;
            this.sendImageButton.Text = "Send";
            this.sendImageButton.UseVisualStyleBackColor = true;
            this.sendImageButton.Click += new System.EventHandler(this.sendImageButton_Click);
            // 
            // sendImageWithErrorFindingButton
            // 
            this.sendImageWithErrorFindingButton.Location = new System.Drawing.Point(594, 362);
            this.sendImageWithErrorFindingButton.Name = "sendImageWithErrorFindingButton";
            this.sendImageWithErrorFindingButton.Size = new System.Drawing.Size(337, 159);
            this.sendImageWithErrorFindingButton.TabIndex = 7;
            this.sendImageWithErrorFindingButton.Text = "Send with error correction";
            this.sendImageWithErrorFindingButton.UseVisualStyleBackColor = true;
            this.sendImageWithErrorFindingButton.Click += new System.EventHandler(this.sendImageWithErrorFindingButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(885, 59);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(55, 40);
            this.chooseFileButton.TabIndex = 8;
            this.chooseFileButton.Text = "...";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(607, 69);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 29);
            this.fileNameLabel.TabIndex = 9;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 699);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "Error Correcting by Emilis Ruzveltas";
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.textTabPage.ResumeLayout(false);
            this.textTabPage.PerformLayout();
            this.imageTabPage.ResumeLayout(false);
            this.imageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedPictureBox)).EndInit();
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
        private System.Windows.Forms.Button sendImageWithErrorFindingButton;
        private System.Windows.Forms.Button sendImageButton;
        private System.Windows.Forms.PictureBox decodedPictureBox;
        private System.Windows.Forms.PictureBox encodedPictureBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

