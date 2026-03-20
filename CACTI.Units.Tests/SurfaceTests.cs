using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Volumes;
using CACTI.Units.Surfaces;
using CACTI.Units.Distances;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class SurfaceTests
    {
        [TestMethod]
        public void ToVolumeTests()
        {
            Volume volume = (SquareCentimeter)10 * (Centimeter)10;
            Assert.AreEqual(volume.Unit, VolumeDimension.CubicCentimeter);
        }

        [TestMethod]
        public void AreConvertionsTest()
        {
            SquareMeter squareMeter = 500;
            Are are = Are.Convert(squareMeter);
            Assert.AreEqual("5 a", are.ToString());

            squareMeter = 30_000;
            Hectare hectare = Hectare.Convert(squareMeter);
            Assert.AreEqual("3 ha", hectare.ToString());
            
            are = Are.Convert(hectare);
            Assert.AreEqual("300 a", are.ToString());

            hectare += are;
            Assert.AreEqual("6 ha", hectare.ToString());
        }

        [TestMethod]
        public void ImperialSurfaceTest()
        {
            Yard yard = 1;
            Foot foot = 30;

            Surface surface = yard * foot;
            Assert.AreEqual(surface.Unit, SurfaceDimension.SquareYard);

            SquareFoot squareFoot = SquareFoot.Convert(surface);
            Assert.AreEqual("90 ft2", squareFoot.ToString("0.##"));
        }
    }
}
