using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    class EncodeManager
    {
        public string NoEncode(string data)
        {
            return data;
        }

        public string Encode(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in data)
            {
                sb.Append($"{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}{c}");
            }

            return sb.ToString();
        }
    }
}
