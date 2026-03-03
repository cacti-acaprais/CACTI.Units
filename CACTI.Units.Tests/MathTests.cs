using CACTI.Units.Distances;
using CACTI.Units.Surfaces;
using CACTI.Units.Speeds;
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
    public class MathTests
    {
        [TestMethod]
        public void DivitionTest()
        {
            KilometerPerHour kilometerPerHour = 50;
            kilometerPerHour /= 2;
            Assert.AreEqual("25 km/h", kilometerPerHour.ToString());
        }

        [TestMethod]
        public void MulitplicationTest()
        {
            Sievert sievert = 3;
            sievert *= 5;
            Assert.AreEqual("15 Sv", sievert.ToString());
        }

        [TestMethod]
        public void AdditionTest()
        {
            Meter meters = 50.555;
            meters += (Decimeter)50;
            Assert.AreEqual("55.555 m", meters.ToString("F3"));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            SquareMeter squareMeter = 120;
            Surface surface = squareMeter - (SquareMeter)30;
            Assert.AreEqual("90 m2", surface.ToString());
        }

        [TestMethod]
        public void DimesionAdditionTest()
        {
            Distance distance = (Centimeter)50.89;
            distance += (Decimeter)50;

            Assert.AreEqual("550.89 cm", distance.ToString("F2"));
        }
    }
}
