using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Countings;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class CountRateTests
    {
        [TestMethod]
        public void CountRateConversionTest()
        {
            CountPerSecond countPerSecond = 10;
            CountPerMinute countPerMinute = CountPerMinute.Convert(countPerSecond);
            Assert.AreEqual(600, countPerMinute.Value, 0.0001);
            CountPerHour countPerHour = CountPerHour.Convert(countPerSecond);
            Assert.AreEqual(36000, countPerHour.Value, 0.0001);
        }
    }
}
