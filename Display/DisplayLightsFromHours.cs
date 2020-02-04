using BerlinClock.Exceptions;
using BerlinClock.Helpers;
using BerlinClock.Interfaces.ClockTime;
using System;
using System.Text;

namespace BerlinClock.Display
{
    public class DisplayLightsFromHours : IClockHoursDisplay
    {
        private const int _LAMPS_PER_LINE = 4;

        public string Display(string hours)
        {
            int parsedHours = TryParseHours(hours);

            var blinkingLights = CalculateTheTurnedOnLightsForTwoRowsOfLamps(parsedHours);

            StringBuilder sb = new StringBuilder();
            sb.Append(ArrangeLampsPerRow(blinkingLights.FirstRow));

            sb.AppendLine();

            sb.Append(ArrangeLampsPerRow(blinkingLights.SecondRow));

            return sb.ToString();
        }

        private int TryParseHours(string hours)
        {
            if (!Int32.TryParse(hours, out int hourss))
            {
                throw new InvalidTimeException($"Invalid clock hours: {hourss}");
            }

            return hourss;
        }

        private string ArrangeLampsPerRow(int nTurnedOnLights)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Constants.RED_BLINKING_LIGHT, nTurnedOnLights);
            if (_LAMPS_PER_LINE - nTurnedOnLights > 0)
            {
                sb.Append(Constants.TURNED_OFF_LIGHT, _LAMPS_PER_LINE - nTurnedOnLights);
            }
            return sb.ToString();
        }


        private BlinkingLights CalculateTheTurnedOnLightsForTwoRowsOfLamps(int hours)
        {
            var nFives = 0;
            var nOnes = 0;
            while (hours > 0)
            {
                if (hours >= 5)
                {
                    nFives++;
                    hours -= 5;
                }
                else
                {
                    nOnes++;
                    hours -= 1;
                }
            }

            return new BlinkingLights(nFives, nOnes); ;
        }
    }
}
