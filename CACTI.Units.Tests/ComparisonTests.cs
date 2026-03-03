using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Speeds;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ComparisonTests
    {
        [TestMethod]
        public void EqualityTest()
        {
            Distance distance = (Kilometer)1;
            Meter meter = 1000;
            Assert.AreEqual(distance, meter);
            Assert.IsTrue(distance == meter);
        }

        [TestMethod]
        public void DifferenceTest()
        {
            Duration duration = (Day)1;
            Hour hour = 12;
            Assert.AreNotEqual(duration, hour);
            Assert.IsTrue(duration != hour);
        }

        [TestMethod]
        public void SuperiorTest()
        {
            Speed speed = (MeterPerSecond)10;
            KilometerPerHour kilometerPerHour = 60;
            Assert.IsTrue(kilometerPerHour > speed);
        }

        [TestMethod]
        public void InferiorTest()
        {
            Duration duration = (Day)1;
            Hour hour = 25;
            Assert.IsTrue(duration < hour);
        }

        [TestMethod]
        public void SuperiorOrEqualTest()
        {
            Speed speed = (MeterPerSecond)10;
            KilometerPerHour kilometerPerHour = 60;
            Assert.IsTrue(kilometerPerHour > speed);
            Assert.IsTrue(kilometerPerHour >= speed);
            Assert.IsTrue(kilometerPerHour != speed);

            MeterPerSecond meterPerSecond = 60;
            kilometerPerHour = 216;
            Assert.IsTrue(meterPerSecond >= kilometerPerHour);
            Assert.IsTrue(meterPerSecond == kilometerPerHour);
        }

        [TestMethod]
        public void InferiorOrEqualTest()
        {
            Duration duration = (Day)1;
            Hour hour = 25;
            Assert.IsTrue(duration < hour);
            Assert.IsTrue(duration <= hour);

            hour = 24;
            Assert.IsTrue(duration <= hour);
            Assert.IsTrue(duration == hour);
        }

        [TestMethod]
        public void DefaultEqualityComparerTest()
        {
            bool comparison = EqualityComparer<Distance>.Default.Equals(default, (Meter)5);
            Assert.IsFalse(comparison);

            comparison = EqualityComparer<Distance>.Default.Equals((Meter)5, default);
            Assert.IsFalse(comparison);

            comparison = EqualityComparer<Distance>.Default.Equals((Meter)5, (Meter)5);
            Assert.IsTrue(comparison);

            comparison = EqualityComparer<Distance>.Default.Equals((Meter)6, (Meter)5);
            Assert.IsFalse(comparison);
        }

        [TestMethod]
        public void NullableUnitDefaultEqualityComparerTest()
        {
            bool comparison = EqualityComparer<Distance?>.Default.Equals(default, (Meter)5);
            Assert.IsFalse(comparison);

            comparison = EqualityComparer<Distance?>.Default.Equals((Meter)5, default);
            Assert.IsFalse(comparison);

            comparison = EqualityComparer<Distance?>.Default.Equals((Meter)5, (Meter)5);
            Assert.IsTrue(comparison);

            comparison = EqualityComparer<Distance?>.Default.Equals((Meter)6, (Meter)5);
            Assert.IsFalse(comparison);
        }
    }
}
