using Microsoft.VisualStudio.TestTools.UnitTesting;
using CACTI.Units;
using System;
using CACTI.Units.Forces;
using CACTI.Units.Accelerations;
using CACTI.Units.Masses;
using CACTI.Units.Ratios;
using CACTI.Units.Distances;
using CACTI.Units.Volumes;
using CACTI.Units.Speeds;
using CACTI.Units.Durations;
using CACTI.Units.Surfaces;
using CACTI.Units.RevolutionSpeeds;
using CACTI.Units.Revolutions;
using CACTI.Units.Gravities;
using CACTI.Units.Temperatures;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestLength()
        {
            Distance length = new Distance(10, DistanceDimension.Meter);
            Assert.AreEqual(10, length.Value);

            Meter meters = 1;
            Millimeter millimeters = Millimeter.Convert(meters);
            Assert.AreEqual(1000, millimeters.Value);
            Meter meters2 = Meter.Convert(millimeters);
            Assert.AreEqual(meters.Value, meters2.Value);
        }

        [TestMethod]
        public void TestLengthMath()
        {
            Meter meter = 10;
            Millimeter millimeter = 1000;
            Distance sum = meter + millimeter;
            Meter sumMeter = Meter.Convert(sum);
            Assert.AreEqual(11, sumMeter.Value);

            Distance sub = meter - millimeter;
            Assert.AreEqual(9, sub.Value);

            Distance result = (meter * 2 + millimeter - millimeter) / 2;
            Assert.AreEqual(10, result.Value);

            Ratio ratio = meter / (Meter)20;
            Percent percent = Percent.Convert(ratio);
            Assert.AreEqual(50, percent.Value);
        }

        [TestMethod]
        public void TestDuration()
        {
            Hour hour = 1;
            Minute minute = Minute.Convert(hour);
            Assert.AreEqual(60, minute);

            Second second = Second.Convert(minute);
            Assert.AreEqual(3600, second);
        }

        [TestMethod]
        public void TestDurationMath()
        {
            Hour hour = 1;
            Minute minute = 30;
            Ratio ratio = minute / hour;
            Assert.AreEqual(0.5, ratio.Value);

            Duration result = minute * 2;
            Hour resultHour = Hour.Convert(result);
            Assert.AreEqual(1, resultHour.Value);

            result = hour / 2;
            Assert.AreEqual(0.5, result.Value);
        }

        [TestMethod]
        public void TestRevolution()
        {
            Revolution revolution = 5;
            Second second = 60;

            RevolutionSpeed revolutionSpeed = revolution / second;
            RevolutionPerMinute revolutionPerMinute = RevolutionPerMinute.Convert(revolutionSpeed);
            Assert.AreEqual(5, revolutionPerMinute.Value);

            RevolutionPerMinute otherRevolutionPerMinute = 10;
            int comparison = otherRevolutionPerMinute.CompareTo(revolutionPerMinute);
            Assert.AreEqual(1, comparison);
        }

        [TestMethod]
        public void TestRevolutionMath()
        {
            RevolutionPerMinute revolutionPerMinute = 10;

        }

        [TestMethod]
        public void TestSpeed()
        {
            Meter meters = 10;
            Second seconds = 2;

            Speed speed = meters / seconds;
            Assert.AreEqual(5, speed.Value);

            MeterPerSecond metersPerSecond = MeterPerSecond.Convert(speed);
            Assert.AreEqual(5, metersPerSecond.Value);

            MeterPerHour meterPerHour = MeterPerHour.Convert(metersPerSecond);
            Assert.AreEqual(18000, meterPerHour.Value);

            KilometerPerHour kilometerPerHour = KilometerPerHour.Convert(metersPerSecond);
            Assert.AreEqual(18, kilometerPerHour.Value);

            int comparison = metersPerSecond.CompareTo(kilometerPerHour);
            Assert.AreEqual(0, comparison);

            Distance length = (KilometerPerHour)18 * (Minute)120;
            Kilometer kilometer = Kilometer.Convert(length);
            Assert.AreEqual(36, kilometer.Value);
        }

        [TestMethod]
        public void SurfaceTest()
        {
            Meter length = 2;
            Meter witdth = 3;

            Surface squareMeter = length * witdth;
            Assert.AreEqual(6, squareMeter.Value);

            SquareCentimeter squareCentimeter = SquareCentimeter.Convert(squareMeter);
            Assert.AreEqual(60000, squareCentimeter);
        }

        [TestMethod]
        public void VolumeTest()
        {
            Meter length = 2;
            Meter witdth = 3;
            Meter height = 2;

            CubicMeter cubicMeter = length * witdth * height;
            Assert.AreEqual(12, cubicMeter.Value);

            CubicCentimeter cubicCentimeter = CubicCentimeter.Convert(cubicMeter);
            Assert.AreEqual(1.2e+7, cubicCentimeter.Value, 0.000001);
        }

        [TestMethod]
        public void AccelerationTest()
        {
            KilometerPerHour kilometerPerHour = 100;
            Second second = 5;

            Acceleration acceleration = kilometerPerHour / second;
            Assert.AreEqual(20, acceleration.Value);

            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Assert.AreEqual(5.556, meterPerSecondPerSecond.Value, 0.001);

            Gravity gravity = Gravity.Convert(acceleration);
            Assert.AreEqual(0.566, gravity.Value, 0.001);

            Newton newton = 100;
            Kilogram kilogram = 20;

            MeterPerSecondPerSecond meterPerSecondPerSecond1 = newton / kilogram;
            Assert.AreEqual(5, meterPerSecondPerSecond1);
        }

        [TestMethod]
        public void ForceTest()
        {
            MeterPerSecondPerSecond acceleration = 5;
            Kilogram mass = 20;
            Newton newton = acceleration * mass;

            Assert.AreEqual(100, newton);

            Dyn dyn = Dyn.Convert(newton);
            Assert.AreEqual(1e7d, dyn);

            KilogramForce kilogramForce = 1;
            Assert.AreEqual(9.80665, Newton.Convert(kilogramForce));
        }

        [TestMethod]
        public void MassTest()
        {
            Kilogram kilogram = 1;
            Gram gram = Gram.Convert(kilogram);

            Assert.AreEqual(1000, gram);

            Mass mass = kilogram * 2;
            Ratio ratio = kilogram / mass;
            Assert.AreEqual(0.5, ratio);
        }

        [TestMethod]
        public void TemperatureTest()
        {
            Celcius celcius = 10;
            Kelvin kelvin = Kelvin.Convert(celcius);
            Assert.AreEqual(283.15, kelvin);

            Farenheight farenheight = Farenheight.Convert(kelvin);
            Assert.AreEqual(50, farenheight);
        }
    }
}
