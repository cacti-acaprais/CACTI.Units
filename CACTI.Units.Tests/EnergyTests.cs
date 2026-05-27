using CACTI.Units.Energies;
using CACTI.Units.Powers;
using CACTI.Units.Durations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class EnergyTests
    {
        [TestMethod]
        public void WattPerHourCreation()
        {
            WattPerHour wattPerHour = 100;
            Assert.AreEqual(100, wattPerHour.Value);
        }

        [TestMethod]
        public void KilowattPerHourConversion()
        {
            WattPerHour wattPerHour = 5000;
            KilowattPerHour kilowattPerHour = KilowattPerHour.Convert(wattPerHour);
            Assert.AreEqual(5, kilowattPerHour.Value, 0.0001);
        }

        [TestMethod]
        public void WattPerSecondToWattPerMinuteConversion()
        {
            WattPerSecond wattPerSecond = 1;
            WattPerMinute wattPerMinute = WattPerMinute.Convert(wattPerSecond);
            Assert.AreEqual(60, wattPerMinute.Value, 0.0001);
        }

        [TestMethod]
        public void EnergyMathOperations()
        {
            WattPerHour wattPerHour = 100;
            Energy doubled = wattPerHour * 2;
            Assert.AreEqual(200, doubled.Value);

            Energy halved = wattPerHour / 2;
            Assert.AreEqual(50, halved.Value);
        }

        [TestMethod]
        public void EnergyFullScaleRoundTrip()
        {
            WattPerSecond wattPerSecond = 42;

            Energy energy = wattPerSecond.Convert(wattPerSecond.Unit);
            foreach (EnergyDimension dimension in EnergyDimension.Units)
            {
                energy = energy.Convert(dimension);
            }
            energy = energy.Convert(wattPerSecond.Unit);

            Assert.AreEqual(wattPerSecond.Value, energy.Value, 0.0000001);
        }
    }
}
