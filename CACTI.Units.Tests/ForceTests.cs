using CACTI.Units.Forces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ForceTests
    {
        [TestMethod]
        public void NewtonToKiloNewtonConversion()
        {
            Newton newton = 5000;
            KiloNewton kiloNewton = KiloNewton.Convert(newton);
            Assert.AreEqual(5, kiloNewton.Value);
        }

        [TestMethod]
        public void PoundForceToNewtonConversion()
        {
            PoundForce poundForce = 1;
            Newton newton = Newton.Convert(poundForce);
            Assert.AreEqual(4.44822, newton.Value, 0.001);
        }

        [TestMethod]
        public void KiloNewtonToMegaNewtonConversion()
        {
            KiloNewton kiloNewton = 2500;
            MegaNewton megaNewton = MegaNewton.Convert(kiloNewton);
            Assert.AreEqual(2.5, megaNewton.Value, 0.0001);
        }

        [TestMethod]
        public void FullScaleConversionRoundTrip()
        {
            Newton newton = 42;

            Force force = newton.Convert(newton.Unit);
            foreach (ForceDimension dimension in ForceDimension.Units)
            {
                force = force.Convert(dimension);
            }
            force = force.Convert(newton.Unit);

            Assert.AreEqual(newton.Value, force.Value, 0.0000001);
        }
    }
}
