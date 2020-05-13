using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public static Time Parse(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
                throw new ArgumentException("Time cannot be empty", nameof(time));

            var split = time.Split(':');
            if (split.Length != 3)
                throw new ArgumentException("Invalid time format", nameof(time));

            return new Time()
            {
                Hours = ParseTimePart(split[0], 24),
                Minutes = ParseTimePart(split[1], 59),
                Seconds = ParseTimePart(split[2], 59)
            };
        }

        private static int ParseTimePart(string input, int maxValue)
        {
            if (int.TryParse(input, out int value) && value >= 0 && value <= maxValue)
                return value;
            else
                throw new ArgumentException("Invalid time format");
        }
    }
}
