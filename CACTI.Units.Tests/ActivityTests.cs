using CACTI.Units.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ActivityTests
    {
        [TestMethod]
        public void BecquerelToDisintegrationPerSecondConversion()
        {
            Becquerel becquerel = 100;
            DisintegrationPerSecond dps = DisintegrationPerSecond.Convert(becquerel);
            Assert.AreEqual(100, dps.Value, 0.0001);
        }

        [TestMethod]
        public void BecquerelToKilobecquerelConversion()
        {
            Becquerel becquerel = 1024;
            Kilobecquerel kilobecquerel = Kilobecquerel.Convert(becquerel);
            Assert.AreEqual(1, kilobecquerel.Value, 0.0001);
        }

        [TestMethod]
        public void BecquerelToMegabecquerelConversion()
        {
            Becquerel becquerel = 1048576;
            Megabecquerel megabecquerel = Megabecquerel.Convert(becquerel);
            Assert.AreEqual(1, megabecquerel.Value, 0.0001);
        }

        [TestMethod]
        public void DisintegrationPerMinuteConversion()
        {
            DisintegrationPerMinute dpm = 60;
            Becquerel becquerel = Becquerel.Convert(dpm);
            Assert.AreEqual(3600, becquerel.Value, 0.0001);
        }

        [TestMethod]
        public void ActivityMathOperations()
        {
            Becquerel becquerel = 1000;
            Activity doubled = becquerel * 2;
            Assert.AreEqual(2000, doubled.Value);

            Activity halved = becquerel / 2;
            Assert.AreEqual(500, halved.Value);
        }

        [TestMethod]
        public void FullScaleConversionRoundTrip()
        {
            Becquerel becquerel = 37000;

            Activity activity = becquerel.Convert(becquerel.Unit);
            foreach (ActivityDimension dimension in ActivityDimension.Units)
            {
                activity = activity.Convert(dimension);
            }
            activity = activity.Convert(becquerel.Unit);

            Assert.AreEqual(becquerel.Value, activity.Value, 0.001);
        }
    }
}
