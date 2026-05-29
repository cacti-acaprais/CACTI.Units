using CACTI.Units.Frequencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class FrequencyTests
    {
        [TestMethod]
        public void HertzToKilohertzConversion()
        {
            Hertz hertz = 5000;
            Kilohertz kilohertz = Kilohertz.Convert(hertz);
            Assert.AreEqual(5, kilohertz.Value);
        }

        [TestMethod]
        public void MegahertzToGigahertzConversion()
        {
            Megahertz megahertz = 2400;
            Gigahertz gigahertz = Gigahertz.Convert(megahertz);
            Assert.AreEqual(2.4, gigahertz.Value, 0.0001);
        }

        [TestMethod]
        public void GigahertzToHertzConversion()
        {
            Gigahertz gigahertz = 1;
            Hertz hertz = Hertz.Convert(gigahertz);
            Assert.AreEqual(1e9, hertz.Value, 0.0001);
        }

        [TestMethod]
        public void FullScaleConversionRoundTrip()
        {
            Hertz hertz = 42;

            Frequency frequency = hertz.Convert(hertz.Unit);
            foreach (FrequencyDimension dimension in FrequencyDimension.Units)
            {
                frequency = frequency.Convert(dimension);
            }
            frequency = frequency.Convert(hertz.Unit);

            Assert.AreEqual(hertz.Value, frequency.Value, 0.0000001);
        }
    }
}
