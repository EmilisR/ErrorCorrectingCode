using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{
    public class ChannelManager
    {
        public string[] SendThroughChannel(string[] data, int probabilityOfDataLoss)
        {
            List<string> bytes = new List<string>();
            Random random = new Random();

            foreach (var bit in data)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bit.Count(); i++)
                {
                    if (random.Next(0, 100) < probabilityOfDataLoss)
                    {
                        if (bit[i] == '0')
                            sb.Append('1');
                        else if (bit[i] == '1')
                            sb.Append('0');
                    }
                    else
                    {
                        sb.Append(bit[i]);
                    }
                }
                bytes.Add(sb.ToString());
            }

            return bytes.ToArray();
        }
    }
}
