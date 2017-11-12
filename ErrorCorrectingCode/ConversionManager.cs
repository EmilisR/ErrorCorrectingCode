using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{

    /// <summary>
    /// Klasė skirta konvertuoti tekstą, paveiksliukus į dvinarį pavidalą
    /// </summary>
    public static class ConversionManager
    {
        public static byte[] TextToBytes(this string text)
        {
            var decimalChars = Encoding.ASCII.GetBytes(text);
            List<byte> bytes = new List<byte>();

            foreach (var symbol in decimalChars)
            {
                var binary = Convert.ToString(symbol, 2).PadLeft(8, '0');
                foreach (var number in binary)
                {
                    bytes.Add(Convert.ToByte(number.ToString()));
                }
            }
            return bytes.ToArray();
        }

        public static string BytesToText(this byte[] bytes)
        {
            var list = new List<List<int>>();
            for (int i = 0; i < bytes.Count(); i += 8)
            {
                list.Add(bytes.Skip(i).Take(8).Select(x => (int)x).ToList());
            }
            return new String(list.Select(s => (char)s.Aggregate((a, b) => a * 2 + b)).ToArray());
        }

        public static string BytesToBinaryString(this byte[] bytes)
        {
            return string.Concat(bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }


        /// <summary>
        /// Konvertuoja string tipo dvinario pavidalo informaciją į byte[] tipą
        /// </summary>
        /// <param name="binaryString">String tipo dvinario pavidalo informacija</param>
        /// <returns></returns>
        public static byte[] BinaryStringToBytes(this string binaryString)
        {
            int numOfBytes = binaryString.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(binaryString.Substring(8 * i, 8), 2);
            }
            return bytes;
        }

        /// <summary>
        /// Konvertuoja paveiksliuką į dvinario pavidalo informaciją
        /// </summary>
        /// <param name="picture">Paveiksliukas</param>
        /// <returns>Dvinario pavidalo informacija</returns>
        public static byte[] BitmapToByteArray(this Bitmap picture)    
        {
            BitmapData pictureData = picture.LockBits(new Rectangle(0, 0, picture.Width, picture.Height), ImageLockMode.ReadOnly, picture.PixelFormat);    
            IntPtr pointer = pictureData.Scan0;   
            Int32 pictureSize = pictureData.Stride * pictureData.Height;  
            byte[] bytes = new byte[pictureSize];  
            System.Runtime.InteropServices.Marshal.Copy(pointer, bytes, 0, pictureSize);
            picture.UnlockBits(pictureData); 
            return bytes;     
        }

        /// <summary>
        /// Konvertuoja dvinario pavidalo informaciją į paveiksliuką
        /// </summary>
        /// <param name="bytes">Dvinario pavidalo informacija</param>
        /// <param name="width">Paveiksliuko plotis</param>
        /// <param name="height">Paveiksliuko aukštis</param>
        /// <returns>Paveiksliukas</returns>
        public static Bitmap ByteArrayToBitmap(this byte[] bytes, int width, int height)   
        {
            Bitmap picture = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData pictureData = picture.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr pointer = pictureData.Scan0;
            Int32 pictureSize = pictureData.Stride * height;
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, pointer, pictureSize);
            picture.UnlockBits(pictureData);
            return picture;     
        }
    }
}
