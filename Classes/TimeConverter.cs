using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            return string.Join(Environment.NewLine, 
                Clock.Zip(GetLampsInRows(Time.Parse(aTime)), (row, lamps) => FormatLampString(row, lamps)));
        }

        private static string FormatLampString(string lampPattern, int lampsOn)
        {
            return lampPattern.Substring(0, lampsOn) + new string(LampOff, lampPattern.Length - lampsOn);
        }

        private static IEnumerable<int> GetLampsInRows(Time time)
        {
            yield return 1 - time.Seconds % 2;
            yield return time.Hours / 5;
            yield return time.Hours % 5;
            yield return time.Minutes / 5;
            yield return time.Minutes % 5;
        }

        private const char LampOff = 'O';
        private static IEnumerable<string> Clock
        {
            get
            {
                yield return "Y";
                yield return "RRRR";
                yield return "RRRR";
                yield return "YYRYYRYYRYY";
                yield return "YYYY";
            }
        }
    }
}
