using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class UnitDimensionTests
    {
        [TestMethod]
        public void SpeedDimensionTest()
        {
            SpeedUnits speedUnits = new SpeedUnits(new LengthUnits(), new DurationUnits());

            MeterPerSecond meterPerSecond = 10;

            Speed speed = meterPerSecond.Convert(meterPerSecond.Unit);

            foreach(SpeedDimension speedDimension in speedUnits.Units)
            {
                 speed = speed.Convert(speedDimension);
            }

            speed = speed.Convert(meterPerSecond.Unit);

            Assert.AreEqual(meterPerSecond, speed);
        }

        [TestMethod]
        public void AccelerationDimensionTest()
        {
            AccelerationUnits accelerationUnits = new AccelerationUnits(new SpeedUnits(new LengthUnits(), new DurationUnits()), new DurationUnits());

            MeterPerSecondPerSecond meterPerSecondPerSecond = 10;

            Acceleration acceleration = meterPerSecondPerSecond.Convert(meterPerSecondPerSecond.Unit);

            foreach (AccelerationDimension accelerationDimension in accelerationUnits.Units)
            {
                acceleration = acceleration.Convert(accelerationDimension);
            }

            acceleration = acceleration.Convert(meterPerSecondPerSecond.Unit);

            Assert.AreEqual(meterPerSecondPerSecond, acceleration);
        }
    }
}
