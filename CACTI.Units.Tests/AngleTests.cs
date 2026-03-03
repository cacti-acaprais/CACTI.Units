using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Angles;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class AngleTests
    {
        [TestMethod]
        public void ConversionTest()
        {
            Angle angle = (Degree)1080;
            Assert.AreEqual("1080 °", angle.ToString());

            Radian radian = Radian.Convert(angle);
            Assert.AreEqual("18.85 rad", radian.ToString("F2"));
        }
    }
}
