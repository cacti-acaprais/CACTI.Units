using CACTI.Units.Powers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void WattToKilowattConversion()
        {
            Watt watt = 5000;
            Kilowatt kilowatt = Kilowatt.Convert(watt);
            Assert.AreEqual(5, kilowatt.Value);
        }

        [TestMethod]
        public void WattToMilliwattConversion()
        {
            Watt watt = 1;
            Milliwatt milliwatt = Milliwatt.Convert(watt);
            Assert.AreEqual(1000, milliwatt.Value);
        }

        [TestMethod]
        public void KilowattToMegawattConversion()
        {
            Kilowatt kilowatt = 2500;
            Megawatt megawatt = Megawatt.Convert(kilowatt);
            Assert.AreEqual(2.5, megawatt.Value);
        }

        [TestMethod]
        public void NanowattToWattConversion()
        {
            Nanowatt nanowatt = 1e9;
            Watt watt = Watt.Convert(nanowatt);
            Assert.AreEqual(1, watt.Value, 0.0001);
        }

        [TestMethod]
        public void MicrowattToMilliwattConversion()
        {
            Microwatt microwatt = 1000;
            Milliwatt milliwatt = Milliwatt.Convert(microwatt);
            Assert.AreEqual(1, milliwatt.Value, 0.0001);
        }

        [TestMethod]
        public void FullScaleConversionRoundTrip()
        {
            Watt watt = 42;

            Power power = watt.Convert(watt.Unit);
            foreach (PowerDimension dimension in PowerDimension.Units)
            {
                power = power.Convert(dimension);
            }
            power = power.Convert(watt.Unit);

            Assert.AreEqual(watt.Value, power.Value, 0.0000001);
        }
    }
}
