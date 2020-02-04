using BerlinClock.Exceptions;
using BerlinClock.Helpers;
using BerlinClock.Interfaces.Display;
using System;
using System.Text;

namespace BerlinClock.Display
{
    public class DisplayLightsFromMinutes : IClockMinutesDisplay
    {
        private const int _FIRST_ROW_SIZE = 11;
        private const int _SECOND_ROW_SIZE = 4;

        public string Display(string minutes)
        {
            var parsedMinutes = TryParseMinutes(minutes);

            StringBuilder sb = new StringBuilder();
            var blinkingLights = CalculateTheTurnedOnLightsForTwoRowsOfLamps(parsedMinutes);
            sb.AppendLine(FirstRow(blinkingLights.FirstRow));
            sb.Append(SecondRow(blinkingLights.SecondRow));
            return sb.ToString();
        }

        private int TryParseMinutes(string minutes)
        {
            if (!Int32.TryParse(minutes, out int parsedMinutes))
            {
                throw new InvalidTimeException($"Invalid clock minutes: {minutes}");
            }
            return parsedMinutes;
        }

        private BlinkingLights CalculateTheTurnedOnLightsForTwoRowsOfLamps(int minutes)
        {
            var nFives = 0;
            var nOnes = 0;
            while (minutes > 0)
            {
                if (minutes >= 5)
                {
                    nFives++;
                    minutes -= 5;
                }
                else
                {
                    nOnes++;
                    minutes -= 1;
                }
            }

            return new BlinkingLights(nFives, nOnes); ;
        }

        private string FirstRow(int nTurnedOnLights)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetDisplayOfFirstRowTurnedOnLights(nTurnedOnLights));
            sb.Append(Constants.TURNED_OFF_LIGHT, _FIRST_ROW_SIZE - nTurnedOnLights);
            return sb.ToString();
        }

        private string GetDisplayOfFirstRowTurnedOnLights(int nBlinkingLights)
        {
            var nTurnedOnLights = 0;
            StringBuilder sb = new StringBuilder();
            while (nTurnedOnLights < nBlinkingLights)
            {
                nTurnedOnLights++;
                if (nTurnedOnLights == 3 || nTurnedOnLights == 6 || nTurnedOnLights == 9)
                {
                    sb.Append(Constants.RED_BLINKING_LIGHT);
                }
                else
                {
                    sb.Append(Constants.YELLOW_BLINKING_LIGHT);
                }
            }

            return sb.ToString();
        }

        private string SecondRow(int nTurnedOnLights)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Constants.YELLOW_BLINKING_LIGHT, nTurnedOnLights);
            sb.Append(Constants.TURNED_OFF_LIGHT, _SECOND_ROW_SIZE - nTurnedOnLights);
            return sb.ToString();
        }
    }
}
