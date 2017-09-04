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
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // encodeTextBox
            // 
            this.encodeTextBox.Location = new System.Drawing.Point(12, 12);
            this.encodeTextBox.Name = "encodeTextBox";
            this.encodeTextBox.Size = new System.Drawing.Size(433, 567);
            this.encodeTextBox.TabIndex = 0;
            this.encodeTextBox.Text = "";
            // 
            // decodeTextBox
            // 
            this.decodeTextBox.Location = new System.Drawing.Point(987, 12);
            this.decodeTextBox.Name = "decodeTextBox";
            this.decodeTextBox.Size = new System.Drawing.Size(445, 567);
            this.decodeTextBox.TabIndex = 1;
            this.decodeTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(547, 178);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(337, 159);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // probabilityTrackBar
            // 
            this.probabilityTrackBar.Location = new System.Drawing.Point(451, 71);
            this.probabilityTrackBar.Maximum = 100;
            this.probabilityTrackBar.Name = "probabilityTrackBar";
            this.probabilityTrackBar.Size = new System.Drawing.Size(337, 101);
            this.probabilityTrackBar.TabIndex = 3;
            this.probabilityTrackBar.ValueChanged += new System.EventHandler(this.probabilityTrackBar_ValueChanged);
            // 
            // probabilityValue
            // 
            this.probabilityValue.Location = new System.Drawing.Point(827, 71);
            this.probabilityValue.Name = "probabilityValue";
            this.probabilityValue.Size = new System.Drawing.Size(100, 35);
            this.probabilityValue.TabIndex = 4;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(481, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(320, 29);
            this.Title.TabIndex = 5;
            this.Title.Text = "Probability of corrupted data:";
            // 
            // sendFindingErrorsButton
            // 
            this.sendFindingErrorsButton.Location = new System.Drawing.Point(547, 376);
            this.sendFindingErrorsButton.Name = "sendFindingErrorsButton";
            this.sendFindingErrorsButton.Size = new System.Drawing.Size(337, 159);
            this.sendFindingErrorsButton.TabIndex = 6;
            this.sendFindingErrorsButton.Text = "Send with error correction";
            this.sendFindingErrorsButton.UseVisualStyleBackColor = true;
            this.sendFindingErrorsButton.Click += new System.EventHandler(this.sendFindingErrorsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 600);
            this.Controls.Add(this.sendFindingErrorsButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.probabilityValue);
            this.Controls.Add(this.probabilityTrackBar);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.decodeTextBox);
            this.Controls.Add(this.encodeTextBox);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox encodeTextBox;
        private System.Windows.Forms.RichTextBox decodeTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TrackBar probabilityTrackBar;
        private System.Windows.Forms.TextBox probabilityValue;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button sendFindingErrorsButton;
    }
}

