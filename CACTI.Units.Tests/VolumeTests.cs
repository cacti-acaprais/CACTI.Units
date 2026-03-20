using CACTI.Units.Surfaces;
using CACTI.Units.Volumes;
using CACTI.Units.Distances;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class VolumeTests
    {
        [TestMethod]
        public void ParseLiterTest()
        {
            Liter? liter = Liter.Parse("5 L");
            Assert.AreEqual("5 L", liter?.ToString());

            liter = Liter.Parse("5 dm3");
            Assert.AreEqual("5 L", liter?.ToString());
        }

        [TestMethod]
        public void LiterCreationTest()
        {
            Liter liter = 5;
            Assert.AreEqual("5 L", liter.ToString());
        }

        [TestMethod]
        public void LiterToVolumeConversionTest()
        {
            Liter liter = 5;
            CubicMeter cubicMeter = CubicMeter.Convert(liter);
            Assert.AreEqual("0.005 m3", cubicMeter.ToString("0.###"));
        }

        [TestMethod]
        public void VolumeToLiterConversionTest()
        {
            CubicMeter cubicMeter = 0.005;
            Liter liter = Liter.Convert(cubicMeter);
            Assert.AreEqual("5 L", liter.ToString("0.##"));
        }

        [TestMethod]
        public void LiterMathematicalOperationTest()
        {
            CubicDecimeter cubicDecimeter = 5;
            Liter liter = Liter.Convert(cubicDecimeter);
            Assert.AreEqual("5 L", liter.ToString("0.###"));

            liter += (Liter)5;
            Assert.AreEqual("10 L", liter.ToString());

            liter += (CubicDecimeter)3;
            Assert.AreEqual("13 L", liter.ToString());
        }

        [TestMethod]
        public void ComparisonTest()
        {
            CubicDecimeter cubicDecimeter = 5;
            Liter liter = 5;

            Assert.IsTrue(cubicDecimeter == liter);
            cubicDecimeter += (Liter)3;

            Assert.IsTrue(cubicDecimeter > liter);
        }

        [TestMethod]
        public void SurfaceToVolumeTest()
        {
            Centimeter width = (Centimeter)5;
            Surface surface = width * (Millimeter)100;
            Volume volume = surface * (Millimeter)20;
            Assert.AreEqual("100 cm3", volume.ToString());

            Meter length = (Meter)5;
            Volume otherVolume = length * (Meter)5 * (Meter)2;
            Assert.AreEqual("50 m3", otherVolume.ToString());
        }

        [TestMethod]
        public void LiterConversionTest()
        {
            Liter liter = 5;
            Milliliter milliliter = Milliliter.Convert(liter);
            Assert.AreEqual("5000 mL", milliliter.ToString());

            Hectoliter hectoliter = Hectoliter.Convert(liter);
            Assert.AreEqual("0.05 hL", hectoliter.ToString("0.##"));
        }

        [TestMethod]
        public void ImperialLiquidVolumeTests()
        {
            Quart quart = 4;
            Gallon gallon = quart;
            Assert.AreEqual("1 gal", gallon.ToString("0.##"));

            Pint pint = gallon;
            Assert.AreEqual("8 pt", pint.ToString("0.##"));

            Liter liter = Liter.Convert(pint);
            Assert.AreEqual("4.55 L", liter.ToString("0.##"));
        }
    }
}
