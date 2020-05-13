using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class TimeParserTests
    {
        [TestMethod]
        public void TestParsingOfProperValues()
        {
            TestTime("00:00:00", 0, 0, 0);
            TestTime("23:59:58", 23, 59, 58);
            TestTime("24:0:0", 24, 0, 0);
            TestTime("13:17:01", 13, 17, 1);
        }

        [TestMethod]
        public void TestParsingOfInvalidValues()
        {
            ExceptException("00:00:-1");
            ExceptException("00:00:60");
            ExceptException("00:60:00");
            ExceptException("25:00:00");
            ExceptException("4:00");
            ExceptException("4");
            ExceptException("");
            ExceptException("midnight");
            ExceptException(null);
        }

        private void ExceptException(string input)
        {
            var exceptionThrown = false;
            try
            {
                // act
                Time time = Time.Parse(input);
            }
            catch
            {
                exceptionThrown = true;
            }
            // assert
            Assert.AreEqual(true, exceptionThrown);
        }

        private void TestTime(string input, int hours, int minutes, int seconds)
        {
            // act
            Time time = Time.Parse(input);

            // assert
            Assert.AreEqual(hours, time.Hours);
            Assert.AreEqual(minutes, time.Minutes);
            Assert.AreEqual(seconds, time.Seconds);
        }
    }
}
