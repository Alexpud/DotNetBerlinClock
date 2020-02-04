using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Unit_Tests.ClockTime
{
    [TestClass]
    public class DisplayLightsFromMinutesTests
    {
        private IClockMinutesDisplay berlinClockMinutesLightsPrinter = new DisplayLightsFromMinutes();

        [TestMethod]
        public void Display_ShouldNotTurnOnLights_When_0Minutes()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("0");
            Assert.AreEqual("00000000000\r\n" + "0000", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Display_ShouldThrowException_When_MinutesAreNotANumber()
        {
            berlinClockMinutesLightsPrinter.Display("a");
        }

        [TestMethod]
        public void Dispaly_ShouldTurnTheFirst2Lights_FromTheFirstRow_When_Its10Minutes()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("10");
            Assert.AreEqual("YY000000000\r\n" + "0000", lights);
        }
    }
}
