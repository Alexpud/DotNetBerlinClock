using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.Display
{
    [TestClass]
    public class DisplayLightsFromSecondsTests
    {
        private IClockSecondsDisplay berlinClockSecondsLampsDisplay = new DisplayLightsFromSeconds();

        [TestMethod]
        public void Display_Should_PrintBlinkingYellowLights_When_SecondsIsNotAOddNumber()
        {
            var lights = berlinClockSecondsLampsDisplay.Display("0");

            Assert.AreEqual("Y", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Display_ShouldThrowException_When_Seconds_Is_Not_A_Number()
        {
            berlinClockSecondsLampsDisplay.Display("a");
        }

        [TestMethod]
        public void Display_Should_PrintNoBlinkingYellowLights_When_SecondsIsAnOddNumber()
        {
            var lights = berlinClockSecondsLampsDisplay.Display("1");

            Assert.AreEqual("O", lights);
        }
    }
}
