using CACTI.Units.Ratios;
using CACTI.Units.Temperatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class TemperatureTests
    {
        [TestMethod]
        public void ConvertToTest()
        {
            Celcius celcius = 10;
            Kelvin kelvin = Kelvin.Convert(celcius);
            Assert.AreEqual(283.5, kelvin);

            Farenheight farenheight = Farenheight.Convert(kelvin);
            Assert.AreEqual(50, farenheight);

            Celcius.Convert(farenheight);
            Assert.AreEqual(10, celcius);
        }


        [TestMethod]
        public void ConvertTest()
        {
            Celcius celcius = 10;

            Temperature temperatureKelvin = celcius.Convert(TemperatureDimension.Kelvin);
            Assert.AreEqual(283.5, temperatureKelvin.Value);
        }

        [TestMethod]
        public void RatioTest()
        {
            Celcius celcius = 10;
            Kelvin kelvin = Kelvin.Convert(celcius);
            Ratio ratio = celcius / kelvin;

            Assert.AreEqual(1, ratio);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Celcius celcius = 5.6;

            Temperature multipliedCelcius = celcius * 10d;
            Assert.AreEqual((Celcius)56, multipliedCelcius);
        }

        [TestMethod]
        public void DivisionTest()
        {
            Celcius celcius = 56;
            Temperature dividedCelcius = celcius / 2;
            Assert.AreEqual((Celcius)28, dividedCelcius);
        }

        [TestMethod]
        public void AdditionTest()
        {
            Celcius celcius = 28;
            Temperature addedCelcius = celcius + (Celcius)2;
            Assert.AreEqual((Celcius)30, addedCelcius);
        }

        [TestMethod]
        public void SubstractionTest()
        {
            Celcius celcius = 30;
            Temperature substractCelcius = celcius - (Celcius)5;
            Assert.AreEqual((Celcius)25, substractCelcius);
        }
    }
}
