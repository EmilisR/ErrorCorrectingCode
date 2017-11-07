﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "paveiksliukai| *.JPG; *.PNG; *.GIF; *.BMP";
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
                            var img = (Bitmap)encodedPictureBox.Image;
                            int psize = img.Size.Height * img.Size.Width * 3 * 8;  
                            bitsCount.Text = $"Paveiksliuko bitų kiekis: {psize.ToString()}";
                        }
                        var fileName = openFileDialog.FileName.Split('\\');
                        fileNameLabel.Text = fileName[fileName.Count() - 1].Length > 15 ? fileName[fileName.Count() - 1].Substring(0, 15) + "..." : fileName[fileName.Count() - 1];
                    }
                    openFileDialog.Dispose();
                    encodedDataWithCoding = "";
                    encodedData = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Klaida");
                }
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "True")
                updateTrackBar(probabilityValue);
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        EncodeManager encodeManager = new EncodeManager();
                        ChannelManager channelManager = new ChannelManager();
                        DecodeManager decodeManager = new DecodeManager();
                        encodedData = encodeManager.NoEncode(string.Join("", encodeTextBox.Text.TextToBytes()));
                        encodedDataWithCoding = encodeManager.Encode(string.Join("", encodeTextBox.Text.TextToBytes()), matrix);
                        var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                        var dataAfterChannelWithCoding = channelManager.SendThroughChannel(encodedDataWithCoding, probabilityTrackBar.Value);
                        var decodedDataString = decodeManager.NoDecode(dataAfterChannel);
                        var decodedData = decodedDataString.BinaryStringToBytes();
                        var decodedDataWithDecodeString = decodeManager.Decode(dataAfterChannelWithCoding, matrix);
                        var errorWithoutCorrection = channelManager.FindErrorsCount(encodedData, decodedDataString);
                        var errorWithCorrection = channelManager.FindErrorsCount(encodedData, decodedDataWithDecodeString);
                        var bitCount = (double)encodedData.Count();
                        textBitCount.Text = $"Teksto bitų kiekis: {bitCount.ToString()}";
                        textWithoutCorrectionErrorsCount.Text = $"Klaidingi bitai be klaidų taisymo: {Math.Round((errorWithoutCorrection / bitCount * 100), 2).ToString()}%";
                        textWithCorrectionErrorsCount.Text = $"Klaidingi bitai su klaidų taisymu: {Math.Round((errorWithCorrection / bitCount * 100), 2).ToString()}%";
                        textCorrectedErrorsCount.Text = $"Ištaisyta klaidų: {Math.Round((double)(errorWithoutCorrection - errorWithCorrection) / errorWithoutCorrection * 100, 2)}%";
                        var decodedDataWithDecode = decodedDataWithDecodeString.Select(x => Convert.ToByte(x.ToString())).ToArray().BytesToText();
                        var decodedDataWithoutDecode = decodedDataString.Select(x => Convert.ToByte(x.ToString())).ToArray().BytesToText();
                        decodeTextBox.Text = decodedDataWithDecode;
                        noDecodeTextBox.Text = decodedDataWithoutDecode;
                        timer.Stop();
                        textStopwatch.Text = $"Praėjęs laikas: {Math.Round((double)timer.ElapsedMilliseconds / 1000, 2)} s.";
                    }
                    else
                    {
                        MessageBox.Show("Įveskite tekstą!", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    if (encodedPictureBox.Image != null)
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        EncodeManager encodeManager = new EncodeManager();
                        ChannelManager channelManager = new ChannelManager();
                        DecodeManager decodeManager = new DecodeManager();
                        if (encodedData == "")
                            encodedData = encodeManager.NoEncode(((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString());
                        if (encodedDataWithCoding == "")
                            encodedDataWithCoding = encodeManager.Encode(((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString(), matrix);
                        var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value);
                        var dataAfterChannelWithCoding = channelManager.SendThroughChannel(encodedDataWithCoding, probabilityTrackBar.Value);
                        var decodedDataString = decodeManager.NoDecode(dataAfterChannel);
                        var decodedData = decodedDataString.BinaryStringToBytes();
                        var decodedDataWithDecodeString = decodeManager.Decode(dataAfterChannelWithCoding, matrix);
                        var bitCount = (double)Convert.ToInt32(bitsCount.Text.Split(' ')[3]);
                        var errorWithoutCorrection = channelManager.FindErrorsCount(encodedData, decodedDataString);
                        var errorWithCorrection = channelManager.FindErrorsCount(encodedData, decodedDataWithDecodeString);
                        withoutCorrectionErrorsCount.Text = $"Klaidingi bitai be klaidų taisymo: {Math.Round((errorWithoutCorrection / bitCount * 100), 2).ToString()}%";
                        withCorrectionErrorsCount.Text = $"Klaidingi bitai su klaidų taisymu: {Math.Round((errorWithCorrection / bitCount * 100), 2).ToString()}%";
                        correctedErrorsCount.Text = $"Ištaisyta klaidų: {Math.Round((double)(errorWithoutCorrection - errorWithCorrection) / errorWithoutCorrection * 100, 2)}%";
                        var decodedDataWithDecode = decodedDataWithDecodeString.BinaryStringToBytes();
                        decodedPictureBox.Image = decodedData.ByteArrayToBitmap(encodedPictureBox.Image.Width, encodedPictureBox.Image.Height);
                        decodedPictureBoxWithCorrecting.Image = decodedDataWithDecode.ByteArrayToBitmap(encodedPictureBox.Image.Width, encodedPictureBox.Image.Height);
                        timer.Stop();
                        stopwatch.Text = $"Praėjęs laikas: {Math.Round((double)timer.ElapsedMilliseconds / 1000, 2)} s.";
                    }
                    else
                    {
                        MessageBox.Show("Atidarykite paveiksliuką!", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void imageProbabilityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            probabilityValue.Text = ((float)probabilityTrackBar.Value / 100).ToString() + "%";
        }

        private void generateMatrixButton_Click(object sender, EventArgs e)
        {
            MatrixEdit matrixForm = new MatrixEdit();
            matrixForm.generate = true;
            if (matrixForm.ShowDialog() == DialogResult.OK)
            {
                matrix = matrixForm.matrix;
                encodedData = "";
                encodedDataWithCoding = "";
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

        private void imageProbabilityValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                updateTrackBar((TextBox)sender);
            }
        }

        private void updateTrackBar(TextBox textBox)
        {
            try
            {
                var number = Convert.ToDecimal(textBox.Text.Replace('%', ' '));
                number *= 100;
                if (number >= 0 && number <= 10000 && (number % 1 == 0))
                {
                    probabilityTrackBar.Value = (int)number;
                    sendButton_Click(true, null);
                }
                    
            }
            catch { }
        }
    }
}
