using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Accelerations;
using CACTI.Units.Speeds;
using CACTI.Units.Durations;
using CACTI.Units.Gravities;
using CACTI.Units.Forces;
using CACTI.Units.Masses;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class AccelerationTests
    {
        [TestMethod]
        public void ConversionTests()
        {
            KilometerPerHour kilometerPerHour = 100;
            Second second = 5;

            Acceleration acceleration = kilometerPerHour / second;
            Assert.AreEqual(20, acceleration.Value);

            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Assert.AreEqual(5.556, meterPerSecondPerSecond.Value, 0.001);

            Gravity gravity = acceleration.ToGravity();
            Assert.AreEqual(0.566, gravity.Value, 0.001);

            Newton newton = 100;
            Kilogram kilogram = 20;

            MeterPerSecondPerSecond meterPerSecondPerSecond1 = newton / kilogram;
            Assert.AreEqual(5, meterPerSecondPerSecond1);
        }

        [TestMethod]
        public void ToGravityTest()
        {
            Acceleration acceleration = (Gravity)10;
            Gravity gravity = acceleration;

            Assert.AreEqual(10, gravity);
        }

        [TestMethod]
        public void ToNewtonTest()
        {
            MeterPerSecondPerDay acceleration = 10;
            Kilogram mass = 10;
            Newton newton = acceleration * mass;
            Acceleration acceleration2 = newton / mass;
            Assert.IsTrue(acceleration.Equals(acceleration2));
        }
    }
}
