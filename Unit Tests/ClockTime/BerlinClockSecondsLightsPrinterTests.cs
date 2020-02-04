using BerlinClock.Converters;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.ClockTime
{
    [TestClass]
    public class BerlinClockSecondsLightsPrinterTests
    {
        private IClockSecondsPrinter secondsConverter = new BerlinClockSecondsLightsPrinter();

        [TestMethod]
        public void Convert_Should_PrintBlinkingYellowLights_When_SecondsIsNotAOddNumber()
        {
            var lights = secondsConverter.Print("0");

            Assert.AreEqual("Y", lights);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Convert_ShouldThrowException_When_Seconds_Is_Not_A_Number()
        {
            secondsConverter.Print("a");
        }

        [TestMethod]
        public void Convert_Should_PrintNoBlinkingYellowLights_When_SecondsIsAnOddNumber()
        {
            var lights = secondsConverter.Print("1");

            Assert.AreEqual("0", lights);
        }
    }
}
