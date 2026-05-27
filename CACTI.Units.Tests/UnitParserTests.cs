using CACTI.Units.Distances;
using CACTI.Units.Temperatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class UnitParserTests
    {
        [TestMethod]
        public void TryParse_ValidSymbol_ReturnsTrue()
        {
            bool result = UnitParser.TryParse("°C", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(TemperatureDimension.Celcius, unit);
        }

        [TestMethod]
        public void TryParse_ValidSymbolWithWhitespace_ReturnsTrue()
        {
            bool result = UnitParser.TryParse("  K  ", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(TemperatureDimension.Kelvin, unit);
        }

        [TestMethod]
        public void TryParse_UnknownSymbol_ReturnsFalse()
        {
            bool result = UnitParser.TryParse("xyz", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsFalse(result);
            Assert.IsNull(unit);
        }

        [TestMethod]
        public void TryParse_EmptyString_ReturnsFalse()
        {
            bool result = UnitParser.TryParse("", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryParse_NullAbbreviation_ThrowsArgumentNullException()
        {
            UnitParser.TryParse<TemperatureDimension>(null!, TemperatureDimension.Units, out _);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryParse_NullUnits_ThrowsArgumentNullException()
        {
            UnitParser.TryParse<TemperatureDimension>("°C", null!, out _);
        }

        [TestMethod]
        public void TryParse_CaseSensitive_DistinguishesCase()
        {
            bool result = UnitParser.TryParse("k", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_FahrenheitSymbol_ReturnsCorrectUnit()
        {
            bool result = UnitParser.TryParse("°F", TemperatureDimension.Units, out TemperatureDimension? unit);
            Assert.IsTrue(result);
            Assert.AreEqual(TemperatureDimension.Fahrenheit, unit);
        }

        [TestMethod]
        public void TryParse_SecondCallUsesCachedLookup()
        {
            UnitParser.TryParse("K", TemperatureDimension.Units, out TemperatureDimension? unit1);
            UnitParser.TryParse("K", TemperatureDimension.Units, out TemperatureDimension? unit2);
            Assert.AreEqual(unit1, unit2);
        }

        [TestMethod]
        public void TryParse_DistanceDimension_FindsMeter()
        {
            bool result = UnitParser.TryParse("m", DistanceDimension.Units, out DistanceDimension? unit);
            Assert.IsTrue(result);
        }
    }
}
