using CACTI.Units.Distances;
using CACTI.Units.Temperatures;
using CACTI.Units.Ratios;
using CACTI.Units.Speeds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class EdgeCaseTests
    {
        [TestMethod]
        public void DefaultStruct_HasZeroValue()
        {
            Distance defaultDistance = default;
            Assert.AreEqual(0, defaultDistance.Value);
        }

        [TestMethod]
        public void DefaultStruct_Equality()
        {
            Distance default1 = default;
            Distance default2 = default;
            Assert.AreEqual(default1, default2);
        }

        [TestMethod]
        public void DefaultStruct_AdditionThrows()
        {
            Distance defaultDistance = default;
            Meter meter = 5;
            Assert.ThrowsException<ArgumentNullException>(() => { Distance _ = defaultDistance + meter; });
        }

        [TestMethod]
        public void CompareTo_DifferentUnits_SameBaseValue()
        {
            Kilometer km = 1;
            Meter meter = 1000;
            int comparison = km.CompareTo((Distance)meter);
            Assert.AreEqual(0, comparison);
        }

        [TestMethod]
        public void CompareTo_DifferentUnits_DifferentBaseValue()
        {
            Kilometer km = 1;
            Meter meter = 999;
            int comparison = km.CompareTo((Distance)meter);
            Assert.AreEqual(1, comparison);
        }

        [TestMethod]
        public void Equals_DifferentUnits_SameBaseValue()
        {
            Kilometer km = 1;
            Meter meter = 1000;
            Assert.IsTrue(km.Equals((Distance)meter));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ratio_NaN_ThrowsException()
        {
            Ratio ratio = new Ratio(double.NaN, RatioDimension.RatioUnit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ratio_Infinity_ThrowsException()
        {
            Ratio ratio = new Ratio(double.PositiveInfinity, RatioDimension.RatioUnit);
        }

        [TestMethod]
        public void TemperatureOffsetArithmetic_AdditionDoesNotDoubleApplyOffset()
        {
            Celcius c1 = 20;
            Celcius c2 = 10;
            Temperature sum = c1 + c2;
            Celcius result = Celcius.Convert(sum);
            Assert.AreEqual(30, result.Value, 0.0001);
        }

        [TestMethod]
        public void TemperatureOffsetArithmetic_SubtractionDoesNotDoubleApplyOffset()
        {
            Celcius c1 = 30;
            Celcius c2 = 10;
            Temperature diff = c1 - c2;
            Celcius result = Celcius.Convert(diff);
            Assert.AreEqual(20, result.Value, 0.0001);
        }

        [TestMethod]
        public void SmallValueConversion_Precision()
        {
            Nanometer nanometer = 1;
            Meter meter = Meter.Convert(nanometer);
            Assert.AreEqual(1e-9, meter.Value, 1e-15);
        }

        [TestMethod]
        public void LargeValueConversion_Precision()
        {
            Megameter megameter = 1;
            Meter meter = Meter.Convert(megameter);
            Assert.AreEqual(1e6, meter.Value, 0.001);
        }

        [TestMethod]
        public void CompareTo_ObjectOfWrongType_ThrowsArgumentException()
        {
            MeterPerSecond speed = 10;
            Assert.ThrowsException<ArgumentException>(() => speed.CompareTo("not a speed"));
        }
    }
}
