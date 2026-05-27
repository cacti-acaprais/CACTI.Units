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
        public void NullComparison()
        {
            MeterPerSecond speed = 10;

            // CompareTo(null) returns 1 for non-default values
            int comparison8 = speed.CompareTo(null);
            Assert.AreEqual(1, comparison8);

            object foo = null;
            int comparison9 = speed.CompareTo(foo);
            Assert.AreEqual(1, comparison9);

            KilometerPerHour speed2 = 10;
            int comparison10 = speed2.CompareTo((object)(Speed)speed);
            Assert.AreEqual(-1, comparison10);

            // Default struct comparisons
            Speed defaultSpeed = default;
            Speed nonDefaultSpeed = (MeterPerSecond)10;
            Assert.AreNotEqual(defaultSpeed, nonDefaultSpeed);
            Assert.AreEqual(default(Speed), defaultSpeed);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Kelvin kelvin = 58;
            Kelvin kelvin2 = 58;

            Assert.AreEqual(kelvin.GetHashCode(), kelvin2.GetHashCode());

            Kelvin kelvin3 = 60;
            Assert.AreNotEqual(kelvin.GetHashCode(), kelvin3.GetHashCode());

            Meter distance = 58;
            Assert.AreNotEqual(kelvin.GetHashCode(), distance.GetHashCode());
        }

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
            int comparison = otherRevolutionPerMinute.CompareTo((RevolutionSpeed)revolutionPerMinute);
            Assert.AreEqual(1, comparison);
        }

        [TestMethod]
        public void TestRevolutionMath()
        {
            RevolutionPerMinute revolutionPerMinute = 10;
            RevolutionPerSecond revolutionPerSecond = 10;
            RevolutionSpeed result = revolutionPerMinute + revolutionPerSecond;
            Assert.AreEqual((RevolutionPerMinute)610, result);
        }

        [TestMethod]
        public void TestSpeed()
        {
            Meter meters = 10;
            Second seconds = 2;

            Speed speed = (Distance)meters / seconds;
            Assert.AreEqual(5, speed.Value);

            MeterPerSecond metersPerSecond = MeterPerSecond.Convert(speed);
            Assert.AreEqual(5, metersPerSecond.Value);

            MeterPerHour meterPerHour = MeterPerHour.Convert(metersPerSecond);
            Assert.AreEqual(18000, meterPerHour.Value);

            KilometerPerHour kilometerPerHour = KilometerPerHour.Convert(metersPerSecond);
            Assert.AreEqual(18, kilometerPerHour.Value);

            int comparison = metersPerSecond.CompareTo((Speed)kilometerPerHour);
            Assert.AreEqual(0, comparison);

            Distance length = (Speed)(KilometerPerHour)18 * (Minute)120;
            Kilometer kilometer = Kilometer.Convert(length);
            Assert.AreEqual(36, kilometer.Value);
        }

        [TestMethod]
        public void SurfaceTest()
        {
            Meter length = 2;
            Meter witdth = 3;

            Surface squareMeter = (Distance)length * witdth;
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

            Volume cubicMeter = (Distance)length * witdth * height;
            Assert.AreEqual(12, cubicMeter.Value);

            CubicCentimeter cubicCentimeter = CubicCentimeter.Convert(cubicMeter);
            Assert.AreEqual(1.2e+7, cubicCentimeter.Value, 0.000001);
        }

        [TestMethod]
        public void ForceTest()
        {
            MeterPerSecondPerSecond acceleration = 5;
            Kilogram mass = 20;
            Newton newton = (Acceleration)acceleration * mass;

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
    }
}
