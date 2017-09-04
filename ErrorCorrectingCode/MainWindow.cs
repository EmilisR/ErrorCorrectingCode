using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCorrectingCode
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
            {
                EncodeManager encodeManager = new EncodeManager();
                var encodedData = encodeManager.Encode(encodeTextBox.Text.TextToBytes());
                ChannelManager channelManager = new ChannelManager();
                var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                DecodeManager decodeManager = new DecodeManager();
                var decodedData = decodeManager.Decode(dataAfterChannel);
                decodeTextBox.Text = decodedData.BytesToText();                
            }
            else
            {
                MessageBox.Show("Enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void probabilityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            probabilityValue.Text = probabilityTrackBar.Value.ToString();
        }

        private void sendFindingErrorsButton_Click(object sender, EventArgs e)
        {
            if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
            {
                EncodeManager encodeManager = new EncodeManager();
                var encodedData = encodeManager.NoEncode(encodeTextBox.Text.TextToBytes());
                ChannelManager channelManager = new ChannelManager();
                var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                DecodeManager decodeManager = new DecodeManager();
                var decodedData = decodeManager.NoDecode(dataAfterChannel);
                decodeTextBox.Text = decodedData.BytesToText();
            }
            else
            {
                MessageBox.Show("Enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;
            encodedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            decodedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            encodedPictureBox.Image = Image.FromStream(myStream);
                        }
                        var fileName = openFileDialog.FileName.Split('\\');
                        fileNameLabel.Text = fileName[fileName.Count() - 1];
                    }
                    openFileDialog.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void sendImageButton_Click(object sender, EventArgs e)
        {
            if (encodedPictureBox.Image != null)
            {
                encodedPictureBox.Image.ImageToBytes();
                /*EncodeManager encodeManager = new EncodeManager();
                var encodedData = encodeManager.NoEncode(encodedPictureBox.Image.ImageToBytes());
                ChannelManager channelManager = new ChannelManager();
                var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                DecodeManager decodeManager = new DecodeManager();
                var decodedData = decodeManager.NoDecode(dataAfterChannel);
                decodedPictureBox.Image = decodedData.BytesToImage();*/
            }
            else
            {
                MessageBox.Show("Open image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendImageWithErrorFindingButton_Click(object sender, EventArgs e)
        {
            if (encodedPictureBox.Image != null)
            {
                /*EncodeManager encodeManager = new EncodeManager();
                var encodedData = encodeManager.NoEncode(encodedPictureBox.Image.ImageToBytes());
                ChannelManager channelManager = new ChannelManager();
                var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                DecodeManager decodeManager = new DecodeManager();
                var decodedData = decodeManager.NoDecode(dataAfterChannel);
                decodedPictureBox.Image = decodedData.BytesToImage();*/
            }
            else
            {
                MessageBox.Show("Open image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
