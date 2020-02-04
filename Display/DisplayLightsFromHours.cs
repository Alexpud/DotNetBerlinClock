using BerlinClock.Exceptions;
using BerlinClock.Helpers;
using BerlinClock.Interfaces.ClockTime;
using System;
using System.Text;

namespace BerlinClock.Display
{
    public class DisplayLightsFromHours : IClockHoursDisplay
    {
        private readonly int _nLampsPerLine = 4;

        public string Display(string hours)
        {
            int hourss = TryParseHours(hours);
            hourss %= 24;

            StringBuilder sb = new StringBuilder();
            var blinkingLights = CalculateTheBlinkingLightsOnEachRow(hourss);

            sb.Append(ArrangeLampsPerRow(blinkingLights.FirstRow));

            sb.AppendLine();

            sb.Append(ArrangeLampsPerRow(blinkingLights.SecondRow));


            return sb.ToString();
        }

        private string ArrangeLampsPerRow(int nLamps)
        {
            StringBuilder sb = new StringBuilder();
            if (_nLampsPerLine - nLamps > 0)
            {
                sb.Append(Constants.TURNED_OFF_LIGHT, _nLampsPerLine - nLamps);
            }
            sb.Append(Constants.RED_BLINKING_LIGHT, nLamps);
            return sb.ToString();
        }

        private static int TryParseHours(string hours)
        {
            if (!Int32.TryParse(hours, out int hourss))
            {
                throw new InvalidTimeException($"Invalid clock hours: {hourss}");
            }

            return hourss;
        }

        private BlinkingLights CalculateTheBlinkingLightsOnEachRow(int hourss)
        {
            var nFives = 0;
            var nOnes = 0;
            while (hourss > 0)
            {
                if (hourss >= 5)
                {
                    nFives++;
                    hourss -= 5;
                }
                else
                {
                    nOnes++;
                    hourss -= 1;
                }
            }

            return new BlinkingLights(nFives, nOnes); ;
        }

        private class BlinkingLights
        {
            public int FirstRow { get; set; }
            public int SecondRow { get; set; }

            public BlinkingLights(int firstRow, int secondRow)
            {
                FirstRow = firstRow;
                SecondRow = secondRow;
            }
        }
    }
}
