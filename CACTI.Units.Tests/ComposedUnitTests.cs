using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Speeds;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ComposedUnitTests
    {
        [TestMethod]
        public void Symbol_SimpleComposition_ReturnsCorrectFormat()
        {
            SISpeedDimension meterPerSecond = new SISpeedDimension(SIDistanceDimension.Meter, DurationDimension.Second);
            Assert.AreEqual("m/s", meterPerSecond.Symbol);
        }

        [TestMethod]
        public void Symbol_KilometerPerHour_ReturnsCorrectFormat()
        {
            SISpeedDimension kmPerHour = new SISpeedDimension(SIDistanceDimension.Kilometer, DurationDimension.Hour);
            Assert.AreEqual("km/h", kmPerHour.Symbol);
        }

        [TestMethod]
        public void ConvertValue_MeterPerSecondToKilometerPerHour()
        {
            SpeedDimension mps = SpeedDimension.MeterPerSecond;
            SpeedDimension kph = SpeedDimension.KilometerPerHour;
            double converted = mps.ConvertValue(1, kph);
            Assert.AreEqual(3.6, converted, 0.0001);
        }

        [TestMethod]
        public void GetBaseValue_And_FromBaseValue_RoundTrip()
        {
            SpeedDimension kph = SpeedDimension.KilometerPerHour;
            double baseValue = kph.GetBaseValue(36);
            double backToKph = kph.FromBaseValue(baseValue);
            Assert.AreEqual(36, backToKph, 0.0001);
        }

        [TestMethod]
        public void StaticInstances_AreEqual()
        {
            SpeedDimension mps1 = SpeedDimension.MeterPerSecond;
            SpeedDimension mps2 = SpeedDimension.MeterPerSecond;
            Assert.AreSame(mps1, mps2);
        }

        [TestMethod]
        public void DifferentCompositions_HaveDifferentSymbols()
        {
            SISpeedDimension mps = new SISpeedDimension(SIDistanceDimension.Meter, DurationDimension.Second);
            SISpeedDimension kph = new SISpeedDimension(SIDistanceDimension.Kilometer, DurationDimension.Hour);
            Assert.AreNotEqual(mps.Symbol, kph.Symbol);
        }

        [TestMethod]
        public void DifferentCompositions_HaveDifferentRatios()
        {
            SISpeedDimension mps = new SISpeedDimension(SIDistanceDimension.Meter, DurationDimension.Second);
            SISpeedDimension kph = new SISpeedDimension(SIDistanceDimension.Kilometer, DurationDimension.Hour);
            Assert.AreNotEqual(mps.Ratio, kph.Ratio);
        }

        [TestMethod]
        public void Dimension_ReturnsCorrectDimension()
        {
            SISpeedDimension mps = new SISpeedDimension(SIDistanceDimension.Meter, DurationDimension.Second);
            Assert.AreEqual(SIDistanceDimension.Meter, mps.Dimension);
        }

        [TestMethod]
        public void BaseDimension_ReturnsCorrectBaseDimension()
        {
            SISpeedDimension mps = new SISpeedDimension(SIDistanceDimension.Meter, DurationDimension.Second);
            Assert.AreEqual(DurationDimension.Second, mps.BaseDimension);
        }
    }
}
