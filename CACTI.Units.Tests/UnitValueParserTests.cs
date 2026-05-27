using CACTI.Units.Distances;
using CACTI.Units.Temperatures;
using CACTI.Units.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class UnitValueParserTests
    {
        [TestMethod]
        public void TryParse_ValueSpaceUnit_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("10 °C", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(10, value);
            Assert.AreEqual(TemperatureDimension.Celcius, unit);
        }

        [TestMethod]
        public void TryParse_ValueNoSpace_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("10°C", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(10, value);
            Assert.AreEqual(TemperatureDimension.Celcius, unit);
        }

        [TestMethod]
        public void TryParse_DecimalValue_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("3.14 °C", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(3.14, value);
        }

        [TestMethod]
        public void TryParse_NegativeValue_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("-3.5 °C", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(-3.5, value);
            Assert.AreEqual(TemperatureDimension.Celcius, unit);
        }

        [TestMethod]
        public void TryParse_InvalidValue_ReturnsFalse()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("abc °C", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_NoUnit_ReturnsFalse()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("5", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_EmptySymbolUnit_ParsesValueOnly()
        {
            bool result = UnitValueParser.TryParse<RatioDimension>("0.5", RatioDimension.Units, CultureInfo.InvariantCulture, out double value, out RatioDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(0.5, value);
        }

        [TestMethod]
        public void TryParse_PercentUnit_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<RatioDimension>("50 %", RatioDimension.Units, CultureInfo.InvariantCulture, out double value, out RatioDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(50, value);
            Assert.AreEqual(RatioDimension.Percent, unit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryParse_NullInput_ThrowsArgumentNullException()
        {
            UnitValueParser.TryParse<TemperatureDimension>(null!, TemperatureDimension.Units, null, out _, out _);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryParse_NullUnits_ThrowsArgumentNullException()
        {
            UnitValueParser.TryParse<TemperatureDimension>("5 °C", null!, null, out _, out _);
        }

        [TestMethod]
        public void TryParse_KelvinSymbol_ReturnsTrue()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("300 K", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(300, value);
            Assert.AreEqual(TemperatureDimension.Kelvin, unit);
        }

        [TestMethod]
        public void TryParse_UnknownUnit_ReturnsFalse()
        {
            bool result = UnitValueParser.TryParse<TemperatureDimension>("5 xyz", TemperatureDimension.Units, CultureInfo.InvariantCulture, out double value, out TemperatureDimension? unit);
            Assert.IsFalse(result);
        }
    }
}
