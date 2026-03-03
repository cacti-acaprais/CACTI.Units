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
    public class ConversionTests
    {
        [TestMethod]
        public void ConversionTest()
        {
            Distance distance = (Meter)5;
            Assert.AreEqual("5 m", distance.ToString());

            Millimeter millimeter = Millimeter.Convert(distance);
            Assert.AreEqual("5000 mm", millimeter.ToString());

            Kilometer kilometer = millimeter;
            Assert.AreEqual("0.005 km", kilometer.ToString());
        }
    }
}
