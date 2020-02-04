using BerlinClock.Exceptions;
using BerlinClock.Helpers;
using BerlinClock.Interfaces.Display;
using System;

namespace BerlinClock.Display
{
    public class DisplayLightsFromSeconds : IClockSecondsDisplay
    {
        public string Display(string seconds)
        {
            if (!Int32.TryParse(seconds, out int parsedSeconds))
            {
                throw new InvalidTimeException($"Invalid clock seconds: {seconds}");
            }
            return parsedSeconds % 2 == 0 ? Constants.YELLOW_BLINKING_LIGHT.ToString() : Constants.TURNED_OFF_LIGHT.ToString();
        }
    }
}
