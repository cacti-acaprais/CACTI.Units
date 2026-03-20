using CACTI.Units.Speeds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class SpeedTests
    {
        [TestMethod]
        public void ImperialToSIDirectConversionTest()
        {
            MilePerHour milePerHour = 10;
            MeterPerSecond meterPerSecond = new MeterPerSecond(milePerHour.Unit.ConvertValue(milePerHour.Value, SpeedDimension.MeterPerSecond));
            Assert.AreEqual(4.4704, meterPerSecond.Value, 0.0001);

            KilometerPerHour kilometerPerHour = KilometerPerHour.Convert(milePerHour);
            Assert.AreEqual(16.0934, kilometerPerHour.Value, 0.0001);
        }
    }
}
