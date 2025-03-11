using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day5
    {
        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var grid = reader.ReadToEnd().Split("\r\n").Select(x => {
                    // Get rows as bytes, then parse to integers instead
                    var asBytes = Encoding.UTF32.GetBytes(x);
                    int[] asInts = new int[asBytes.Length / 4];
                    Buffer.BlockCopy(asBytes, 0, asInts, 0, asBytes.Length);
                    return asInts;
                    }).ToList();

                var poopCount = 0;

                var x = -2;
                var y = -1;

                while (y != grid.Count - 1) {
                    // Move first
                    x = (x + 2) % grid[0].Count();
                    y += 1;
                    
                    // Then check if it's poop
                    var pos = grid[y][x];
                    if (pos == 0x1F4A9)
                    {
                        poopCount++;
                    }
                }

                Console.WriteLine(poopCount);
            }
        }
    }
}
