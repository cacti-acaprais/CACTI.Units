﻿using CACTI.Units.Accelerations;
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
    public class UnitDimensionTests
    {
        [TestMethod]
        public void SpeedDimensionTest()
        {
            
            MeterPerSecond meterPerSecond = 10;

            Speed speed = meterPerSecond.Convert(meterPerSecond.Unit);

            foreach(SpeedDimension speedDimension in SpeedDimension.Units)
            {
                 speed = speed.Convert(speedDimension);
            }

            speed = speed.Convert(meterPerSecond.Unit);

            Assert.AreEqual(meterPerSecond.Value, speed.Value, 0.00000001d);
        }

        [TestMethod]
        public void AccelerationDimensionTest()
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = 10;

            Acceleration acceleration = meterPerSecondPerSecond.Convert(meterPerSecondPerSecond.Unit);

            foreach (AccelerationDimension accelerationDimension in AccelerationDimension.Units)
            {
                acceleration = acceleration.Convert(accelerationDimension);
            }

            acceleration = acceleration.Convert(meterPerSecondPerSecond.Unit);

            Assert.AreEqual(meterPerSecondPerSecond.Value, acceleration.Value, 0.00000001d);
        }
    }
}
