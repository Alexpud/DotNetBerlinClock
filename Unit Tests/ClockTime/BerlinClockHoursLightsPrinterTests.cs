using BerlinClock.Converters;
using BerlinClock.Exceptions;
using BerlinClock.Interfaces.ClockTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests.ClockTime
{
    [TestClass]
    public class BerlinClockHoursLightsPrinterTests
    {
        private IClockHoursPrinter berlinClockHoursLampsPrinter = new BerlinClockHoursLightsPrinter();

        [TestMethod]
        public void Print_Should_PrintEmpty_When_Printing_ZeroHours()
        {
            var hours = berlinClockHoursLampsPrinter.Print("0");

            Assert.AreEqual("0000\r\n" + "0000", hours);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidTimeException))]
        public void Print_Should_ThrowException_When_Passing_A_NonNumber_Value()
        {
            berlinClockHoursLampsPrinter.Print("a");
        }

        [TestMethod]
        public void Print_Should_ReturnFirstRow_Of_BlinkingRedLights_When_Its_20Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Print("20");
            Assert.AreEqual("RRRR\r\n" + "0000", hours);
        }

        [TestMethod]
        public void Print_Should_ReturnSecondRow_Of_BlinkingRedLights_When_Its_4Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Print("4");
            Assert.AreEqual("0000\r\n" + "RRRR", hours);
        }

        [TestMethod]
        public void Print_Should_ReturnBothRows_Of_BlinkingRedLights_When_Its_24Hours()
        {
            var hours = berlinClockHoursLampsPrinter.Print("24");
            Assert.AreEqual("RRRR\r\n" + "RRRR", hours);
        }

        [TestMethod]
        public void Print_Should_ParseHoursGreater_Than_24_As_CyclesOf24()
        {
            var hours = berlinClockHoursLampsPrinter.Print("28");
            Assert.AreEqual("0000\r\n" + "RRRR", hours);
        }
    }
}
