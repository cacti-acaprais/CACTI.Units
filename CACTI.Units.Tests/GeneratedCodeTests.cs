using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Temperatures;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class GeneratedCodeTests
    {
        [TestMethod]
        public void CallGeneratedCode()
        {
            string symbol = TemperatureDimension.Celcius.Symbol;
            Assert.AreEqual("°C", symbol);
        }
    }
}
