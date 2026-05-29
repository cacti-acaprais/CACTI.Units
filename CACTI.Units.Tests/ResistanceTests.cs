using CACTI.Units.Resistances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ResistanceTests
    {
        [TestMethod]
        public void OhmToMilliOhmConversion()
        {
            Ohm ohm = 1;
            MilliOhm milliOhm = MilliOhm.Convert(ohm);
            Assert.AreEqual(1000, milliOhm.Value);
        }

        [TestMethod]
        public void OhmToMicroOhmConversion()
        {
            Ohm ohm = 1;
            MicroOhm microOhm = MicroOhm.Convert(ohm);
            Assert.AreEqual(1e6, microOhm.Value);
        }

        [TestMethod]
        public void MilliOhmToOhmConversion()
        {
            MilliOhm milliOhm = 4700;
            Ohm ohm = Ohm.Convert(milliOhm);
            Assert.AreEqual(4.7, ohm.Value, 0.0001);
        }

        [TestMethod]
        public void ResistanceMathOperations()
        {
            Ohm ohm = 100;
            Resistance doubled = ohm * 2;
            Assert.AreEqual(200, doubled.Value);

            Resistance halved = ohm / 2;
            Assert.AreEqual(50, halved.Value);
        }

        [TestMethod]
        public void OhmToKiloOhmConversion()
        {
            Ohm ohm = 4700;
            KiloOhm kiloOhm = KiloOhm.Convert(ohm);
            Assert.AreEqual(4.7, kiloOhm.Value, 0.0001);
        }

        [TestMethod]
        public void KiloOhmToMegaOhmConversion()
        {
            KiloOhm kiloOhm = 2200;
            MegaOhm megaOhm = MegaOhm.Convert(kiloOhm);
            Assert.AreEqual(2.2, megaOhm.Value, 0.0001);
        }
    }
}
