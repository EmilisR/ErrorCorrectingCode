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
        private string encodedData = "";
        private string encodedDataWithCoding = "";
        private byte[,] matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            /*if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
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
            }*/
        }

        private void probabilityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            probabilityValue.Text = probabilityTrackBar.Value.ToString() + "%";
        }

        private void sendFindingErrorsButton_Click(object sender, EventArgs e)
        {
            /*if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
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
            }*/
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "images| *.JPG; *.PNG; *.GJF";
            openFileDialog.RestoreDirectory = true;
            encodedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            decodedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            decodedPictureBoxWithCorrecting.SizeMode = PictureBoxSizeMode.StretchImage;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                encodedData = "";

                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            encodedPictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        }
                        var fileName = openFileDialog.FileName.Split('\\');
                        fileNameLabel.Text = fileName[fileName.Count() - 1].Length > 15 ? fileName[fileName.Count() - 1].Substring(0, 15) + "..." : fileName[fileName.Count() - 1];
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
                EncodeManager encodeManager = new EncodeManager();
                ChannelManager channelManager = new ChannelManager();
                DecodeManager decodeManager = new DecodeManager();
                if (encodedData == "")
                    encodedData = encodeManager.NoEncode(((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString());
                if (encodedDataWithCoding == "")
                    encodedDataWithCoding = encodeManager.Encode(((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString(), matrix);
                var dataAfterChannel = channelManager.SendThroughChannel(encodedData, imageProbabilityTrackBar.Value);
                var dataAfterChannelWithCoding = channelManager.SendThroughChannel(encodedDataWithCoding, imageProbabilityTrackBar.Value);
                var decodedData = decodeManager.NoDecode(dataAfterChannel).BinaryStringToBytes();
                var decodedDataWithDecode = decodeManager.Decode(dataAfterChannelWithCoding, matrix).BinaryStringToBytes();
                decodedPictureBox.Image = decodedData.ByteArrayToBitmap(encodedPictureBox.Image.Width, encodedPictureBox.Image.Height);
                decodedPictureBoxWithCorrecting.Image = decodedDataWithDecode.ByteArrayToBitmap(encodedPictureBox.Image.Width, encodedPictureBox.Image.Height);
            }
            else
            {
                MessageBox.Show("Open image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imageProbabilityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            imageProbabilityValue.Text = imageProbabilityTrackBar.Value.ToString() + "%";
        }

        private void setMatrixButton_Click(object sender, EventArgs e)
        {
            MatrixEdit matrixForm = new MatrixEdit();
            if (matrixForm.ShowDialog()  == DialogResult.OK)
            {
                matrix = matrixForm.matrix;
            }
        }

        private void generateMatrixButton_Click(object sender, EventArgs e)
        {
            MatrixEdit matrixForm = new MatrixEdit();
            matrixForm.generate = true;
            if (matrixForm.ShowDialog() == DialogResult.OK)
            {
                matrix = matrixForm.matrix;
            }
        }

        private void viewMatrixButton_Click(object sender, EventArgs e)
        {
            if (matrix != null)
            {
                MatrixEdit matrixForm = new MatrixEdit(matrix);
                matrixForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Matrica dar nesugeneruota", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
