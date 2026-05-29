using CACTI.Units.Masses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class MassTests
    {
        [TestMethod]
        public void GramToKilogramConversion()
        {
            Gram gram = 1000;
            Kilogram kilogram = Kilogram.Convert(gram);
            Assert.AreEqual(1, kilogram.Value);
        }

        [TestMethod]
        public void MilligramToGramConversion()
        {
            Milligram milligram = 500;
            Gram gram = Gram.Convert(milligram);
            Assert.AreEqual(0.5, gram.Value, 0.0001);
        }

        [TestMethod]
        public void KilogramToMetricTonConversion()
        {
            Kilogram kilogram = 2500;
            MetricTon metricTon = MetricTon.Convert(kilogram);
            Assert.AreEqual(2.5, metricTon.Value, 0.0001);
        }

        [TestMethod]
        public void PoundToKilogramConversion()
        {
            Pound pound = 1;
            Kilogram kilogram = Kilogram.Convert(pound);
            Assert.AreEqual(0.453592, kilogram.Value, 0.001);
        }

        [TestMethod]
        public void OunceToGramConversion()
        {
            Ounce ounce = 1;
            Gram gram = Gram.Convert(ounce);
            Assert.AreEqual(28.3495, gram.Value, 0.001);
        }

        [TestMethod]
        public void PoundToOunceConversion()
        {
            Pound pound = 1;
            Ounce ounce = Ounce.Convert(pound);
            Assert.AreEqual(16, ounce.Value, 0.01);
        }

        [TestMethod]
        public void StoneToKilogramConversion()
        {
            Stone stone = 1;
            Kilogram kilogram = Kilogram.Convert(stone);
            Assert.AreEqual(6.35029, kilogram.Value, 0.001);
        }

        [TestMethod]
        public void MassFullScaleRoundTrip()
        {
            Gram gram = 42;

            Mass mass = gram.Convert(gram.Unit);
            foreach (MassDimension dimension in MassDimension.Units)
            {
                mass = mass.Convert(dimension);
            }
            mass = mass.Convert(gram.Unit);

            Assert.AreEqual(gram.Value, mass.Value, 0.0000001);
        }
    }
}
