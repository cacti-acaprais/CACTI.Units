using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Resistances;
using CACTI.Units.Voltages;
using CACTI.Units.Currents;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class VotageTests
    {
        [TestMethod]
        public void ToResistanceTests()
        {
            Resistance resistance = (MilliVolt)10 / (MilliAmpere)10;
            Assert.IsTrue(resistance.Unit.Equals(ResistanceDimension.MilliOhm));
            Assert.AreEqual((MilliOhm)1, resistance);

            Resistance resistance2 = (MilliVolt)10 / (Ampere)10;
            Assert.IsTrue(resistance2.Unit.Equals(ResistanceDimension.MilliOhm));
            Assert.AreEqual((MilliOhm)0.001, resistance2);

            Resistance resistance3 = (Volt)10 / (MicroAmpere)1000;
            Assert.IsTrue(resistance3.Unit.Equals(ResistanceDimension.Ohm));
            Assert.AreEqual((Ohm)10000, resistance3);
        }
    }
}
