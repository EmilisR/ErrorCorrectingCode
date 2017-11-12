using System;
using System.Text;

namespace ErrorCorrectingCode
{

    /// <summary>
    /// Klasė, skirta siųsti kanalu pranešimą ir jį iškraipyti su tikimybe
    /// </summary>
    public class ChannelManager
    {

        /// <summary>
        /// Gautą pranešimą iškraipo su tikimybe
        /// </summary>
        /// <param name="binaryString">Pranešimas</param>
        /// <param name="probabilityOfDataLoss">Iškraipymo tikimybė (1-10000)</param>
        /// <param name="notSendLast">Kiek paskutiniųjų bitų neiškraipyti (techninė informacija)</param>
        /// <returns>Iškraipytas pranešimas</returns>
        public string SendThroughChannel(string binaryString, int probabilityOfDataLoss, int notSendLast = 0)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            var lastOne = binaryString.LastIndexOf('1');
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (random.Next(0, 10000) < probabilityOfDataLoss && i < (binaryString.Length - notSendLast))
                {
                    if (binaryString[i] == '0')
                        sb.Append('1');
                    else if (binaryString[i] == '1')
                        sb.Append('0');
                }
                else
                {
                    sb.Append(binaryString[i]);
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Apskaičiuoja kiek buvo padaryta klaidų iškraipant pranešimą
        /// </summary>
        /// <param name="before">Pirminis pranešimas</param>
        /// <param name="after">Pranešimas po iškraipymo</param>
        /// <returns>Klaidų skaičius</returns>
        public int FindErrorsCount(string before, string after)
        {
            int counter = 0;
            for (int i = 0; i < before.Length; i++)
            {
                if (before[i] != after[i])
                    counter++;
            }
            return counter;
        }
    }
}
