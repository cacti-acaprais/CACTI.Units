using CACTI.Units.Pressures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class PressureTests
    {
        [TestMethod]
        public void PascalToKilopascalConversion()
        {
            Pascal pascal = 5000;
            Kilopascal kilopascal = Kilopascal.Convert(pascal);
            Assert.AreEqual(5, kilopascal.Value);
        }

        [TestMethod]
        public void BarToPascalConversion()
        {
            Bar bar = 1;
            Pascal pascal = Pascal.Convert(bar);
            Assert.AreEqual(1e5, pascal.Value);
        }

        [TestMethod]
        public void AtmosphereToPascalConversion()
        {
            Atmosphere atmosphere = 1;
            Pascal pascal = Pascal.Convert(atmosphere);
            Assert.AreEqual(101325, pascal.Value);
        }

        [TestMethod]
        public void PsiToPascalConversion()
        {
            Psi psi = 1;
            Pascal pascal = Pascal.Convert(psi);
            Assert.AreEqual(6894.76, pascal.Value, 0.01);
        }

        [TestMethod]
        public void TorrToPascalConversion()
        {
            Torr torr = 760;
            Pascal pascal = Pascal.Convert(torr);
            Assert.AreEqual(101324.72, pascal.Value, 0.1);
        }

        [TestMethod]
        public void AtmosphereToBarConversion()
        {
            Atmosphere atmosphere = 1;
            Bar bar = Bar.Convert(atmosphere);
            Assert.AreEqual(1.01325, bar.Value, 0.00001);
        }

        [TestMethod]
        public void FullScaleConversionRoundTrip()
        {
            Pascal pascal = 42;

            Pressure pressure = pascal.Convert(pascal.Unit);
            foreach (PressureDimension dimension in PressureDimension.Units)
            {
                pressure = pressure.Convert(dimension);
            }
            pressure = pressure.Convert(pascal.Unit);

            Assert.AreEqual(pascal.Value, pressure.Value, 0.0000001);
        }
    }
}
