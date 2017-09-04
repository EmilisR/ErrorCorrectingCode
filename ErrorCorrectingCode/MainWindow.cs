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
                MessageBox.Show("Encode text box is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Encode text box is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
