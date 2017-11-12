using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCorrectingCode
{

    /// <summary>
    /// 
    /// </summary>
    public class ChannelManager
    {
        public string SendThroughChannel(string binaryString, int probabilityOfDataLoss)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            foreach (var bit in binaryString)
            {
                if (random.Next(0, 10000) <= probabilityOfDataLoss)
                {
                    if (bit == '0')
                        sb.Append('1');
                    else if (bit == '1')
                        sb.Append('0');
                }
                else
                {
                    sb.Append(bit);
                }
            }
            return sb.ToString();
        }

        public int FindErrorsCount(string before, string after)
        {
            int counter = 0;
            before = before.Substring(0, after.Length);
            for (int i = 0; i < before.Length; i++)
            {
                if (before[i] != after[i])
                    counter++;
            }
            return counter;
        }
    }
}
