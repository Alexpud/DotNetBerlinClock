using BerlinClock.Display;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.Display;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.Display
{
    [TestClass]
    public class DisplayLightFromHoursTests
    {
        private IClockHoursDisplay berlinClockHoursLampsDisplay = new DisplayLightsFromHours();

        [TestMethod]
        public void Display_Should_PrintEmpty_When_Printing_ZeroHours()
        {
            var hours = berlinClockHoursLampsDisplay.Display("0");

            Assert.AreEqual("OOOO\r\n" + "OOOO", hours);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Display_Should_ThrowException_When_Passing_A_NonNumber_Value()
        {
            berlinClockHoursLampsDisplay.Display("a");
        }

        [TestMethod]
        public void Display_Should_ReturnFirstRow_Of_BlinkingRedLights_When_Its_20Hours()
        {
            var hours = berlinClockHoursLampsDisplay.Display("20");
            Assert.AreEqual("RRRR\r\n" + "OOOO", hours);
        }

        [TestMethod]
        public void Display_Should_ReturnSecondRow_Of_BlinkingRedLights_When_Its_4Hours()
        {
            var hours = berlinClockHoursLampsDisplay.Display("4");
            Assert.AreEqual("OOOO\r\n" + "RRRR", hours);
        }

        [TestMethod]
        public void Display_Should_ReturnBothRows_Of_BlinkingRedLights_When_Its_24Hours()
        {
            var hours = berlinClockHoursLampsDisplay.Display("24");
            Assert.AreEqual("RRRR\r\n" + "RRRR", hours);
        }
    }
}
