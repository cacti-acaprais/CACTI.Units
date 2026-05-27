using CACTI.Units.Currents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class CurrentConversionTests
    {
        [TestMethod]
        public void AmpereToMilliAmpereConversion()
        {
            Ampere ampere = 1;
            MilliAmpere milliAmpere = MilliAmpere.Convert(ampere);
            Assert.AreEqual(1000, milliAmpere.Value);
        }

        [TestMethod]
        public void AmpereToMicroAmpereConversion()
        {
            Ampere ampere = 1;
            MicroAmpere microAmpere = MicroAmpere.Convert(ampere);
            Assert.AreEqual(1e6, microAmpere.Value);
        }

        [TestMethod]
        public void MilliAmpereToAmpereConversion()
        {
            MilliAmpere milliAmpere = 500;
            Ampere ampere = Ampere.Convert(milliAmpere);
            Assert.AreEqual(0.5, ampere.Value);
        }

        [TestMethod]
        public void MicroAmpereToMilliAmpereConversion()
        {
            MicroAmpere microAmpere = 2500;
            MilliAmpere milliAmpere = MilliAmpere.Convert(microAmpere);
            Assert.AreEqual(2.5, milliAmpere.Value, 0.0001);
        }

        [TestMethod]
        public void CurrentMathOperations()
        {
            Ampere ampere = 5;
            Current doubled = ampere * 2;
            Assert.AreEqual(10, doubled.Value);

            MilliAmpere milliAmpere = 500;
            Current sum = ampere + milliAmpere;
            Assert.AreEqual(5.5, sum.Value);
        }
    }
}
