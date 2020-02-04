using BerlinClock.Display;
using BerlinClock.Interfaces.Display;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private IClockMinutesDisplay _minutesDisplay = new DisplayLightsFromMinutes();
        private IClockHoursDisplay _hoursDisplay = new DisplayLightsFromHours();
        private IClockSecondsDisplay _secondsDisplay = new DisplayLightsFromSeconds();


        public string convertTime(string aTime)
        {
            var time = aTime.Split(':');
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_secondsDisplay.Display(time[2]));
            sb.AppendLine(_hoursDisplay.Display(time[0]));
            sb.Append(_minutesDisplay.Display(time[1]));
            return sb.ToString();
        }
    }
}
