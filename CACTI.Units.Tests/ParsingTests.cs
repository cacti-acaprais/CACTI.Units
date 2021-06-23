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

    }
}
