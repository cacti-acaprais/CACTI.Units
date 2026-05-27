using CACTI.Units.Currents;
using CACTI.Units.Voltages;
using CACTI.Units.Resistances;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Surfaces;
using CACTI.Units.Volumes;
using CACTI.Units.Radiations;
using CACTI.Units.Revolutions;
using CACTI.Units.RevolutionSpeeds;
using CACTI.Units.Forces;
using CACTI.Units.Masses;
using CACTI.Units.Accelerations;
using CACTI.Units.Speeds;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class CrossDimensionalTests
    {
        [TestMethod]
        public void OhmsLaw_CurrentTimesResistance_ReturnsVoltage()
        {
            Ampere ampere = 2;
            Ohm ohm = 50;
            Volt volt = (Current)ampere * ohm;
            Assert.AreEqual(100, volt.Value);
        }

        [TestMethod]
        public void OhmsLaw_VoltageOverCurrent_ReturnsResistance()
        {
            Volt volt = 100;
            Ampere ampere = 2;
            Resistance resistance = (Voltage)volt / ampere;
            Assert.AreEqual(50, resistance.Value, 0.0001);
        }

        [TestMethod]
        public void SurfaceTimesDistance_ReturnsVolume()
        {
            SquareMeter squareMeter = 10;
            Meter meter = 5;
            Volume volume = (Surface)squareMeter * meter;
            Assert.AreEqual(50, volume.Value);
        }

        [TestMethod]
        public void DoseOverDuration_ReturnsRate()
        {
            Sievert sievert = 10;
            Hour hour = 2;
            Rate rate = (Dose)sievert / hour;
            Assert.AreEqual(5, rate.Value);
            Assert.AreEqual("5 Sv/h", rate.ToString());
        }

        [TestMethod]
        public void RateTimesDuration_ReturnsDose()
        {
            SievertPerHour sievertPerHour = 5;
            Hour hour = 3;
            Dose dose = (Rate)sievertPerHour * hour;
            Assert.AreEqual(15, dose.Value);
        }

        [TestMethod]
        public void RevolutionOverDuration_ReturnsRevolutionSpeed()
        {
            Revolution revolution = 120;
            Minute minute = 1;
            RevolutionSpeed speed = revolution / minute;
            Assert.AreEqual(120, speed.Value);
        }

        [TestMethod]
        public void ForceOverMass_ReturnsAcceleration()
        {
            Newton newton = 100;
            Kilogram kilogram = 10;
            MeterPerSecondPerSecond acceleration = (Force)newton / kilogram;
            Assert.AreEqual(10, acceleration.Value);
        }

        [TestMethod]
        public void AccelerationTimesMass_ReturnsForce()
        {
            MeterPerSecondPerSecond acceleration = 9.80665;
            Kilogram mass = 10;
            Newton newton = (Acceleration)acceleration * mass;
            Assert.AreEqual(98.0665, newton.Value, 0.0001);
        }

        [TestMethod]
        public void SpeedTimesDuration_ReturnsDistance()
        {
            KilometerPerHour kph = 60;
            Hour hour = 2;
            Distance distance = (Speed)kph * hour;
            Kilometer km = Kilometer.Convert(distance);
            Assert.AreEqual(120, km.Value, 0.0001);
        }

        [TestMethod]
        public void DistanceOverDuration_ReturnsSpeed()
        {
            Kilometer km = 100;
            Hour hour = 2;
            Speed speed = (Distance)km / hour;
            KilometerPerHour kph = KilometerPerHour.Convert(speed);
            Assert.AreEqual(50, kph.Value, 0.0001);
        }

        [TestMethod]
        public void SpeedOverDuration_ReturnsAcceleration()
        {
            MeterPerSecond mps = 30;
            Second second = 10;
            Acceleration acceleration = (Speed)mps / second;
            MeterPerSecondPerSecond mpsps = MeterPerSecondPerSecond.Convert(acceleration);
            Assert.AreEqual(3, mpsps.Value, 0.0001);
        }
    }
}
