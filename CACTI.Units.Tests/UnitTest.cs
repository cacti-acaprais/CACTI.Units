using Microsoft.VisualStudio.TestTools.UnitTesting;
using CACTI.Units;

namespace UnitsTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestLength()
        {
            Length length = new Length(10, LengthUnits.Meter);
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
            Length sum = meter + millimeter;
            Meter sumMeter = Meter.Convert(sum);
            Assert.AreEqual(11, sumMeter.Value);

            Length sub = meter - millimeter;
            Assert.AreEqual(9, sub.Value);

            Length result = (meter * 2 + millimeter - millimeter) / 2;
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

            Length length = (KilometerPerHour)18 * (Minute)120;
            Kilometer kilometer = Kilometer.Convert(length);
            Assert.AreEqual(36, kilometer.Value);
        }

        [TestMethod]
        public void SurfaceTest()
        {
            Meter length = 2;
            Meter witdth = 3;

            SquareMeter squareMeter = length * witdth;
            Assert.AreEqual(6, squareMeter.Value);
        }

        [TestMethod]
        public void VolumeTest()
        {
            Meter length = 2;
            Meter witdth = 3;
            Meter height = 2;

            CubicMeter cubicMeter = length * witdth * height;
            Assert.AreEqual(12, cubicMeter.Value);
        }

        [TestMethod]
        public void AccelerationTest()
        {
            KilometerPerHour kilometerPerHour = 100;
            Second second = 5;

            Acceleration acceleration = kilometerPerHour / second;
            Assert.AreEqual(20, acceleration.Value);

            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Assert.AreEqual(5.555555555555555, meterPerSecondPerSecond.Value);

            Gravity gravity = acceleration;
            Assert.AreEqual(0.5665090072099601, gravity.Value);

            
        }
    }
}
