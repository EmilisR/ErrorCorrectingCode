using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    public static class ConversionManager
    {
        public static string[] TextToBytes(this string text)
        {
            var decimalChars = Encoding.ASCII.GetBytes(text);
            List<string> bytes = new List<string>();

            foreach (var symbol in decimalChars)
            {
                bytes.Add(Convert.ToString(symbol, 2));
            }

            return bytes.ToArray();
        }

        public static byte[] ImageToBytes(this Image image)
        {
            Image newImage = (Image)image.Clone();
            image.Dispose();
            Byte[] result
    = (Byte[])new ImageConverter().ConvertTo(newImage, typeof(Byte[]));
            return result;
        }

        public static string BytesToText(this string[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bit in bytes)
            {
                sb.Append((char)Convert.ToInt32(bit, 2));
            }

            return sb.ToString();
        }

        public static Image BytesToImage(this byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
