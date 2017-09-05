using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    public class DecodeManager
    {
        public string NoDecode(string data)
        {
            return data;
        }

        public string Decode(string data)
        {
            StringBuilder sb = new StringBuilder();
            var size = data.Count();

            for (int i = 0; i < size - 14; i += 15)
            {
                var str = 0;

                for (int j = i; j < i + 15; j++)
                {
                    str += Convert.ToByte(data[j].ToString());
                }

                if (str > 7)
                    sb.Append("1");
                else
                    sb.Append("0");
            }
            var a = sb.Length;
            return sb.ToString();
        }
    }
}
