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
    }
}
