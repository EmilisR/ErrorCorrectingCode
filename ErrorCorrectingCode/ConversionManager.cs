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
    /// 
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

        public static byte[] BinaryStringToBytes(this string binaryString)
        {
            if (binaryString.Length % 8 != 0)
                binaryString += new String('0', binaryString.Length % 8);

            int numOfBytes = binaryString.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(binaryString.Substring(8 * i, 8), 2);
            }
            return bytes;
        }

        public static byte[] BitmapToByteArray(this Bitmap img)    
        {
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);    
            int pixelbytes = Image.GetPixelFormatSize(img.PixelFormat) / 8;   
            IntPtr ptr = bmpData.Scan0;   
            Int32 psize = bmpData.Stride * bmpData.Height;  
            byte[] byOut = new byte[psize];  
            System.Runtime.InteropServices.Marshal.Copy(ptr, byOut, 0, psize);    
            img.UnlockBits(bmpData); 
            return byOut;     
        }

        public static Bitmap ByteArrayToBitmap(this byte[] byteIn, int imwidth, int imheight)   
        {
            Bitmap picOut = new Bitmap(imwidth, imheight, PixelFormat.Format24bppRgb);
            BitmapData bmpData = picOut.LockBits(new Rectangle(0, 0, imwidth, imheight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * imheight;
            System.Runtime.InteropServices.Marshal.Copy(byteIn, 0, ptr, psize);
            picOut.UnlockBits(bmpData);
            return picOut;     
        }
    }
}
