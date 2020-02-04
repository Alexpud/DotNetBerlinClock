using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.ClockTime
{
    [TestClass]
    public class DisplayLightsFromMinutesTests
    {
        private IClockMinutesDisplay berlinClockMinutesLightsPrinter = new DisplayLightsFromMinutes();

        [TestMethod]
        public void Display_ShouldNotTurnOnLights_When_0Minutes()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("0");
            Assert.AreEqual("OOOOOOOOOOO\r\n" + "OOOO", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Display_ShouldThrowException_When_MinutesAreNotANumber()
        {
            berlinClockMinutesLightsPrinter.Display("a");
        }

        [TestMethod]
        public void Display_ShouldTurnTheFirst2Lights_FromTheFirstRow_When_Its10Minutes()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("10");
            Assert.AreEqual("YYOOOOOOOOO\r\n" + "OOOO", lights);
        }

        [TestMethod]
        public void Display_ShouldTurnAllLights_FromTheFirstRow_When_Its55Minutes()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("55");
            Assert.AreEqual("YYRYYRYYRYY\r\n" + "OOOO", lights);
        }

        [TestMethod]
        public void Display_ShouldTurnOnlyTheFirstYellowLight_FromTheSecondRow_When_Its1Minute()
        {
            var lights = berlinClockMinutesLightsPrinter.Display("1");
            Assert.AreEqual("OOOOOOOOOOO\r\n" + "YOOO", lights);
        }
    }
}
