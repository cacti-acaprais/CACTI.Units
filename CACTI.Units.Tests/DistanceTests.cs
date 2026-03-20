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
    public class DistanceTests
    {
        [TestMethod]
        public void SIDistanceToImperialDistanceConversionTest()
        {
            Meter meter = 1;
            Inch inch = Inch.Convert(meter);
            Assert.AreEqual("39.37 in", inch.ToString("0.##"));
            Foot foot = inch;
            Assert.AreEqual("3.28 ft", foot.ToString("0.##"));
        }
    }
}
