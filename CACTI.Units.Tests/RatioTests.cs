using CACTI.Units.Ratios;
using CACTI.Units.Radiations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class RatioTests
    {
        [TestMethod]
        public void GetRatioTest()
        {
            Ratio ratio = (MillisievertPerHour)50 / (MillisievertPerHour)200;
            Assert.AreEqual("0.25", ratio.ToString());
        }

        [TestMethod]
        public void AdditionTest()
        {
            MillisievertPerHour millisievertPerHour = (MillisievertPerHour)50 + (Percent)50;
            Assert.AreEqual("75 mSv/h", millisievertPerHour.ToString());
        }
    }
}
