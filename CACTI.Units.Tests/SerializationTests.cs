using CACTI.Units.Distances;
using CACTI.Units.Ratios;
using CACTI.Units.Speeds;
using CACTI.Units.Temperatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializationTest()
        {
            Meter distance = 50.555;

            Assert.AreEqual("50.555 m", distance.ToString());
            Assert.AreEqual("50.555 m", string.Format("{0}", distance));

            Assert.AreEqual("50.55 m", distance.ToString("F2"));
            Assert.AreEqual("50.55 m", string.Format("{0:F2}", distance));
        }

        [TestMethod]
        public void ParsingTest()
        {
            Assert.IsTrue(Distance.TryParse("5 m", out Distance? distance));
            Assert.AreEqual("5 m", distance.ToString());

            Assert.IsTrue(Millimeter.TryParse("5 m", out Millimeter? millimeters));
            Assert.AreEqual("5000 mm", millimeters.ToString());

            Assert.IsFalse(Temperature.TryParse("5 m", out Temperature? temperature));
            Assert.IsTrue(temperature is null);

            Assert.IsTrue(Fahrenheit.TryParse("5°C", out Fahrenheit? fahrenheit));
            Assert.AreEqual("41 °F", fahrenheit.ToString());

            Celcius celcius = (Celcius)fahrenheit;
            Assert.AreEqual("5 °C", celcius.ToString());

            Speed? speed = Speed.Parse("5 m/s");
            Assert.AreEqual("5 m/s", speed?.ToString());

            KilometerPerHour? kilometerPerHour = KilometerPerHour.Parse("5 m/s");
            Assert.AreEqual("18 km/h", kilometerPerHour?.ToString());

            Ratio? ratio = Ratio.Parse("25 %");
        }

        [TestMethod]
        public void JsonSerializationTest()
        {
            Percent percent = (Percent)10;
            string percentJson = JsonSerializer.Serialize(percent);

            Percent? otherPercent = JsonSerializer.Deserialize<Percent>(percentJson);

            Assert.AreEqual(percent, otherPercent);
        }
    }
}
