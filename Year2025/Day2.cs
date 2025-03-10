using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day2
    {
        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                // Clever code, because I thought it would be funny
                // I would never do this in practice
                Console.WriteLine(reader.ReadToEnd()
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => DateTimeOffset.Parse(x))
                    .GroupBy(x => x)
                    .Where(x => x.Count() >= 4)
                    .Single()
                    .Key
                    .ToUniversalTime()
                    .ToString("s") + "+00:00");
                //2019-06-05T12:15:00+00:00
            }
        }
    }
}
