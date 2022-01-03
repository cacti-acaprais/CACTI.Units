using CACTI.Units.Currents;
using CACTI.Units.Ratios;
using CACTI.Units.RevolutionSpeeds;
using CACTI.Units.Temperatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class ParsingTests
    {
        [TestMethod]
        public void CurrentParsingTest()
        {
            Ampere reference = 14.3;
            string text = reference.ToString("F3");
            if(Current.TryParse(text, out Current? current))
            {
                Assert.AreEqual(reference.Value, current.Value);
                Assert.AreEqual(reference.Unit.Symbol, current.Unit.Symbol);
            }
            else
            {
                throw new AssertFailedException($"Parsing failed");
            }
        }

        [TestMethod]
        public void RevolutionSpeedParsingTest()
        {
            RevolutionPerSecond reference = 10;
            string text = reference.ToString();
            if (RevolutionSpeed.TryParse(text, out RevolutionSpeed? revolutionSpeed))
            {
                Assert.AreEqual(reference.Value, revolutionSpeed.Value);
                Assert.AreEqual(reference.Unit.Symbol, revolutionSpeed.Unit.Symbol);
            }
            else
            {
                throw new AssertFailedException($"Parsing failed");
            }
        }

        [TestMethod]
        public void RatioParsingTest()
        {
            Ratio reference = 10;
            string text = reference.ToString();
            if(Ratio.TryParse(text, out Ratio? ratio))
            {
                Assert.AreEqual(reference.Value, ratio.Value);
                Assert.AreEqual(reference.Unit.Symbol, ratio.Unit.Symbol);
            }
            else
            {
                throw new AssertFailedException($"Parsing failed");
            }
        }

        [TestMethod]
        public void InvalidUnitlessParsingTest()
        {
            string text = "20";
            bool result = Temperature.TryParse(text, out Temperature? temperature);
            Assert.IsFalse(result);
        }

    }
}
