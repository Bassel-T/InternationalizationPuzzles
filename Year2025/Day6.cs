using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day6
    {
        private class Helper
        {
            public int Length { get; set; }
            public char Given { get; set; }
            public int GivenPosition { get; set; }
        }

        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var line = reader.ReadLine();
                var words = new List<string>();
                var limits = new List<Helper>();

                while (!string.IsNullOrWhiteSpace(line))
                {
                    words.Add(line);
                    line = reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Trim();

                    var given = line.Single(char.IsLetter);
                    var pos = line.Split(given)[0].Count(x => x == '.');
                    var length = line.Length;

                    limits.Add(new()
                    {
                        Length = length,
                        Given = given,
                        GivenPosition = pos
                    });
                }

                var decoded = words.Select((x, i) =>
                {
                    var word = x;

                    if (i % 3 == 2)
                    {
                        word = Encoding.UTF8.GetString(Encoding.Latin1.GetBytes(word));
                    }

                    if (i % 5 == 4)
                    {
                        word = Encoding.UTF8.GetString(Encoding.Latin1.GetBytes(word));
                    }

                    return word;
                }).ToList();

                var score = 0;

                foreach (var limit in limits)
                {
                    var match = decoded.Single(x => x.Length == limit.Length && x[limit.GivenPosition] == limit.Given);
                    score += decoded.IndexOf(match) + 1;
                }

                Console.WriteLine(score);
            }
        }
    }
}
