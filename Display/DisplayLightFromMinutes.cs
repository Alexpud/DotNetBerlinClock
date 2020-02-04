using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using System;
using System.Text;

namespace BerlinClock.Display
{
    public class DisplayLightsFromMinutes : IClockMinutesDisplay
    {
        public string Display(string minutes)
        {
            if (!Int32.TryParse(minutes, out int parsedMinutes))
            {
                throw new InvalidTimeException($"Invalid clock minutes: {minutes}");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(FirstRow(parsedMinutes));
            sb.Append('0', 11);
            sb.AppendLine();
            sb.Append('0', 4);
            return sb.ToString();
        }

        private string FirstRow(int minutes)
        {
            StringBuilder sb = new StringBuilder();
            if (minutes - 10 > 0)
            {
                minutes -= 10;
                sb.Append('Y', 2);
            }
        }
    }
}
