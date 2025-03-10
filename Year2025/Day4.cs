using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InternationalizationPuzzles.Year2025
{
    public static class Day4
    {
        public static void Solution()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var input = reader.ReadToEnd().Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
                double output = 0;

                Regex startRegex = new Regex(@"Departure:\s+(?<timezone>[\w/-]+)\s+(?<datetime>.+)");
                Regex endRegex = new Regex(@"Arrival:\s+(?<timezone>[\w/-]+)\s+(?<datetime>.+)");

                foreach (var data in input)
                {
                    var lines = data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                    var depart = startRegex.Match(lines[0]);
                    var start = DateTimeOffset.Parse(depart.Groups["datetime"].Value);
                    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(depart.Groups["timezone"].Value);
                    start = new DateTimeOffset(start.DateTime, tz.GetUtcOffset(start.DateTime));

                    var arrival = endRegex.Match(lines[1]);
                    var end = DateTimeOffset.Parse(arrival.Groups["datetime"].Value);
                    TimeZoneInfo tz2 = TimeZoneInfo.FindSystemTimeZoneById(arrival.Groups["timezone"].Value);
                    end = new DateTimeOffset(end.DateTime, tz2.GetUtcOffset(end.DateTime));

                    output += (end - start).TotalMinutes;

                    Console.WriteLine((end - start).TotalMinutes);
                }

                Console.WriteLine(output);
            }
        }
    }
}
