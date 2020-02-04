using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.ClockTime
{
    [TestClass]
    public class DisplayLightFromHoursTests
    {
        private IClockHoursDisplay berlinClockHoursLampsPrinter = new DisplayLightsFromHours();

        [TestMethod]
        public void Print_Should_PrintEmpty_When_Printing_ZeroHours()
        {
            var hours = berlinClockHoursLampsPrinter.Display("0");

            Assert.AreEqual("OOOO\r\n" + "OOOO", hours);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Print_Should_ThrowException_When_Passing_A_NonNumber_Value()
        {
            berlinClockHoursLampsPrinter.Display("a");
        }

        [TestMethod]
        public void Print_Should_ReturnFirstRow_Of_BlinkingRedLights_When_Its_20Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Display("20");
            Assert.AreEqual("RRRR\r\n" + "OOOO", hours);
        }

        [TestMethod]
        public void Print_Should_ReturnSecondRow_Of_BlinkingRedLights_When_Its_4Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Display("4");
            Assert.AreEqual("OOOO\r\n" + "RRRR", hours);
        }

        [TestMethod]
        public void Print_Should_ReturnBothRows_Of_BlinkingRedLights_When_Its_24Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Display("24");
            Assert.AreEqual("RRRR\r\n" + "RRRR", hours);
        }
    }
}
