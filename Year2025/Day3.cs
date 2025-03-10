using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day3
    {
        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var valid = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Length < 4 || line.Length > 12)
                        continue;

                    if (!line.Any(char.IsDigit))
                        continue;

                    if (!line.Any(char.IsLower))
                        continue;

                    if (!line.Any(char.IsUpper))
                        continue;

                    if (line.All(x => x <= 127))
                        continue;

                    valid++;
                }

                Console.WriteLine(valid);
            }
        }
    }
}
