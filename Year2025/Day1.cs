using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day1
    {
        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var smsMaxLength = 160; // bytes
                var smsCost = 11;

                var tweetLength = 140; // characters
                var tweetCost = 7;

                var totalCost = 0;

                while (!reader.EndOfStream)
                {
                    var localCost = 0;

                    var line = reader.ReadLine();
                    if (line.Length <= tweetLength)
                        localCost += tweetCost;

                    var lineBytes = UTF8Encoding.UTF8.GetBytes(line);
                    if (lineBytes.Length <= smsMaxLength)
                        localCost += smsCost;

                    if (localCost == 18)
                        localCost = 13;

                    totalCost += localCost;
                }

                Console.WriteLine(totalCost);
            }
        }

        public static void Part2()
        {

        }
    }
}
