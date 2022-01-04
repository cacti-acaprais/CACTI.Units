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
    }
}
