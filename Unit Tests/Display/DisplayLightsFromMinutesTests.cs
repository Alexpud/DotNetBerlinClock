using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.Display;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.Display
{
    [TestClass]
    public class DisplayLightsFromMinutesTests
    {
        private IClockMinutesDisplay berlinClockMinutesLightsDisplay = new DisplayLightsFromMinutes();

        [TestMethod]
        public void Display_ShouldNotTurnOnLights_When_0Minutes()
        {
            var lights = berlinClockMinutesLightsDisplay.Display("0");
            Assert.AreEqual("OOOOOOOOOOO\r\n" + "OOOO", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Display_ShouldThrowException_When_MinutesAreNotANumber()
        {
            berlinClockMinutesLightsDisplay.Display("a");
        }

        [TestMethod]
        public void Display_ShouldTurnTheFirst2Lights_FromTheFirstRow_When_Its10Minutes()
        {
            var lights = berlinClockMinutesLightsDisplay.Display("10");
            Assert.AreEqual("YYOOOOOOOOO\r\n" + "OOOO", lights);
        }

        [TestMethod]
        public void Display_ShouldTurnAllLights_FromTheFirstRow_When_Its55Minutes()
        {
            var lights = berlinClockMinutesLightsDisplay.Display("55");
            Assert.AreEqual("YYRYYRYYRYY\r\n" + "OOOO", lights);
        }

        [TestMethod]
        public void Display_ShouldTurnOnlyTheFirstYellowLight_FromTheSecondRow_When_Its1Minute()
        {
            var lights = berlinClockMinutesLightsDisplay.Display("1");
            Assert.AreEqual("OOOOOOOOOOO\r\n" + "YOOO", lights);
        }
    }
}
