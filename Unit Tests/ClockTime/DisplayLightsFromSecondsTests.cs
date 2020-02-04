using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.ClockTime
{
    [TestClass]
    public class DisplayLightsFromSecondsTests
    {
        private IClockSecondsDisplay secondsConverter = new DisplayLightsFromSeconds();

        [TestMethod]
        public void Print_Should_PrintBlinkingYellowLights_When_SecondsIsNotAOddNumber()
        {
            var lights = secondsConverter.Display("0");

            Assert.AreEqual("Y", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Print_ShouldThrowException_When_Seconds_Is_Not_A_Number()
        {
            secondsConverter.Display("a");
        }

        [TestMethod]
        public void Print_Should_PrintNoBlinkingYellowLights_When_SecondsIsAnOddNumber()
        {
            var lights = secondsConverter.Display("1");

            Assert.AreEqual("O", lights);
        }
    }
}
