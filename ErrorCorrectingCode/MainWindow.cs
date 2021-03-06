﻿using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ErrorCorrectingCode
{
    /// <summary>
    /// Pagrindinio programos lango klasė
    /// </summary>
    public partial class MainWindow : Form
    {
        private string encodedData = "";
        private string encodedDataWithCoding = "";
        private byte[,] matrix;
        private EncodeManager encodeManager = new EncodeManager();
        private ChannelManager channelManager = new ChannelManager();
        private DecodeManager decodeManager = new DecodeManager();

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Metodas skirtas atidaryti failų pasirinkimo langą ir užkrauti paveiksliuką į programą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Vykdyti atkodavimą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Matrica dar nesugeneruota", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sender.ToString() != "True")
                updateTrackBar(probabilityValue);
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    if (encodeTextBox.Text != string.Empty || encodeTextBox.Text != "")
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        var textEncodedData = string.Join("", encodeTextBox.Text.TextToBytes());
                        var textEncodedDataWithCoding = encodeManager.Encode(string.Join("", encodeTextBox.Text.TextToBytes()), matrix);
                        var textDataAfterChannel = channelManager.SendThroughChannel(textEncodedData, probabilityTrackBar.Value, matrix.GetLength(0) * 2);
                        var textDataAfterChannelWithCoding = channelManager.SendThroughChannel(textEncodedDataWithCoding, probabilityTrackBar.Value, matrix.GetLength(0)*2);
                        var textDecodedData = textDataAfterChannel.BinaryStringToBytes();
                        var textDecodedDataWithDecodeString = decodeManager.Decode(textDataAfterChannelWithCoding, matrix);
                        var errorWithoutCorrection = channelManager.FindErrorsCount(textEncodedData, textDataAfterChannel);
                        var errorWithCorrection = channelManager.FindErrorsCount(textEncodedData, textDecodedDataWithDecodeString);
                        var bitCount = (double)textEncodedData.Count();
                        textBitCount.Text = $"Teksto bitų kiekis: {bitCount.ToString()}";
                        textWithoutCorrectionErrorsCount.Text = $"Klaidingi bitai be klaidų taisymo: {Math.Round((errorWithoutCorrection / bitCount * 100), 2).ToString()}%";
                        textWithCorrectionErrorsCount.Text = $"Klaidingi bitai su klaidų taisymu: {Math.Round((errorWithCorrection / bitCount * 100), 2).ToString()}%";
                        textCorrectedErrorsCount.Text = $"Ištaisyta klaidų: {Math.Round((double)(errorWithoutCorrection - errorWithCorrection) / errorWithoutCorrection * 100, 2)}%";
                        var decodedDataWithDecode = textDecodedDataWithDecodeString.Select(x => Convert.ToByte(x.ToString())).ToArray().BytesToText();
                        var decodedDataWithoutDecode = textDataAfterChannel.Select(x => Convert.ToByte(x.ToString())).ToArray().BytesToText();

                        decodeTextBox.Text = decodedDataWithDecode.Replace("\0", "");
                        noDecodeTextBox.Text = decodedDataWithoutDecode.Replace("\0", "");
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
                        if (encodedData == "")
                            encodedData = ((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString();
                        if (encodedDataWithCoding == "")
                            encodedDataWithCoding = encodeManager.Encode(((Bitmap)(encodedPictureBox.Image)).BitmapToByteArray().BytesToBinaryString(), matrix);
                        var dataAfterChannel = channelManager.SendThroughChannel(encodedData, probabilityTrackBar.Value, matrix.GetLength(0) * 2);
                        var dataAfterChannelWithCoding = channelManager.SendThroughChannel(encodedDataWithCoding, probabilityTrackBar.Value, matrix.GetLength(0) * 2);
                        var decodedData = dataAfterChannel.BinaryStringToBytes();
                        var decodedDataWithDecodeString = decodeManager.Decode(dataAfterChannelWithCoding, matrix);
                        var bitCount = (double)Convert.ToInt32(bitsCount.Text.Split(' ')[3]);
                        var errorWithoutCorrection = channelManager.FindErrorsCount(encodedData, dataAfterChannel);
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

        /// <summary>
        /// Atvaizduoja tikimybės procentą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageProbabilityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            probabilityValue.Text = ((float)probabilityTrackBar.Value / 100).ToString() + "%";
        }

        /// <summary>
        /// Atidaromas matricos sukūrimo langas ir išsaugoma sukurta matrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Atvaizduoja sugeneruotą matricą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Atnaujina tikimybės procentą kai paspaudžiamas Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageProbabilityValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                updateTrackBar((TextBox)sender);
            }
        }

        /// <summary>
        /// Apskaičiuojamas tikimybės procentas iš vartotojo įvesto teksto
        /// </summary>
        /// <param name="textBox"></param>
        private void updateTrackBar(TextBox textBox)
        {
            try
            {
                var number = Convert.ToDecimal(textBox.Text.Replace('%', ' '));
                number *= 100;
                if (number >= 0 && number <= 10000 && (number % 1 == 0))
                {
                    probabilityTrackBar.Value = (int)number;
                }
                    
            }
            catch { }
        }

        /// <summary>
        /// Validuoja vektorių jei paspaudžiamas Enter esant vektoriaus kortelėje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    validateVector(((TextBox)sender).Text, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Validuoja vektorių jei paspaudžiamas Enter esant vektoriaus kortelėje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateVector(string text, bool input)
        {
            if (text.Any(x => x != '1' && x != '0'))
            {
                throw new Exception("Vektorius turi būti sudarytas tik iš 0 ir 1");
            }
            if (matrix == null)
            {
                throw new Exception("Nesugeneruota matrica");
            }
            if (matrix != null && text.Length != matrix.GetLength(input ? 0 : 1))
            {
                throw new Exception($"Vektoriaus ilgis {text.Length} netinkamas, turi būti {matrix.GetLength(input ? 0 : 1)}");
            } 
        }

        /// <summary>
        /// Atkoduoja vektorių, parodo vietas, kuriose atsirado klaidos esant vektoriaus kortelėje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void encodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateVector(inputText.Text, true);
                decodeButton.Enabled = true;
                var encodedDataWithCoding = encodeManager.EncodeOneVector(inputText.Text, matrix);
                encodedVectorText.Text = encodedDataWithCoding;
                var dataAfterChannelWithCoding = channelManager.SendThroughChannel(encodedDataWithCoding, probabilityTrackBar.Value);
                afterChannelVectorText.Text = dataAfterChannelWithCoding;
                afterChannelVectorText.Enabled = true;
                showErrors(encodedVectorText.Text, afterChannelVectorText.Text);
                
            }
            catch (Exception ex)
            {
                setState(false);
                decodeButton.Enabled = false;
                MessageBox.Show(ex.Message, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Parodo klaidas atkoduotame vektoriuje esant vektoriaus kortelėje
        /// </summary>
        /// <param name="original"></param>
        /// <param name="afterChannel"></param>
        private void showErrors(string original, string afterChannel)
        {
            var selectionStart = afterChannelVectorText.SelectionStart;
            if (original.Length == afterChannel.Length)
            {
                afterChannelVectorText.SelectAll();
                afterChannelVectorText.SelectionColor = Color.Black;
                afterChannelVectorText.SelectionBackColor = Color.White;
                afterChannelVectorText.DeselectAll();
                for (int i = 0; i < original.Length; i++)
                {
                    if (original[i] != afterChannel[i])
                    {
                        afterChannelVectorText.SelectionStart = i;
                        afterChannelVectorText.SelectionLength = 1;
                        afterChannelVectorText.SelectionColor = Color.Red;
                        afterChannelVectorText.SelectionBackColor = Color.Yellow;
                    }
                    afterChannelVectorText.Select(selectionStart, 0);
                }
            }
        }

        /// <summary>
        /// Pakeičia mygtuko „Apdoroti“ būseną
        /// </summary>
        /// <param name="enable"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            sendImageButton.Enabled = tabControl.SelectedIndex != 2;
        }

        /// <summary>
        /// Iškviečia klaidų parodymo metodą kai yra pakeičiamas tekstas 
        /// atkoduoto vektoriaus tekstiniame lauke vektoriaus kortelėje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afterChannelVectorText_TextChanged(object sender, EventArgs e)
        {
            showErrors(encodedVectorText.Text, afterChannelVectorText.Text);
        }

        /// <summary>
        /// Atkoduoja vektorių ir patikrina ar atitinka pradinį vektorių vektoriaus kortelėje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decodeButton_Click(object sender, EventArgs e)
        {
            validateVector(afterChannelVectorText.Text, false);
            var decodedData = decodeManager.DecodeOneVector(afterChannelVectorText.Text, matrix);
            decodedStartVectorText.Text = decodedData.Item1;
            decodedVectorText.Text = decodedData.Item2;
            setState(decodedStartVectorText.Text.Equals(inputText.Text));
        }
        
        /// <summary>
        /// Nustato būsenos lauko būseną atsižvelgiant į tai, ar atkoduotas vektorius yra teisingas
        /// </summary>
        /// <param name="correct"></param>
        private void setState(bool correct)
        {
            if (correct)
            {
                state.Text = "Teisingai";
                state.TextAlign = HorizontalAlignment.Center;
                state.BackColor = Color.Green;
            }
            else
            {
                state.Text = "Neteisingai";
                state.TextAlign = HorizontalAlignment.Center;
                state.BackColor = Color.Red;
            }
        }
    }
}
