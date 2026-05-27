using CACTI.Units.Distances;
using CACTI.Units.Currents;
using CACTI.Units.Voltages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class TryGetCompatibleUnitTests
    {
        [TestMethod]
        public void TryGetCompatibleUnit_SameRatio_FindsMatch()
        {
            VoltageDimension volt = VoltageDimension.Volt;
            bool found = volt.TryGetCompatibleUnit(CurrentDimension.Units, out CurrentDimension? compatible);
            Assert.IsTrue(found);
            Assert.AreEqual(CurrentDimension.Ampere, compatible);
        }

        [TestMethod]
        public void TryGetCompatibleUnit_NoMatch_ReturnsFalse()
        {
            SIDistanceDimension kilometer = SIDistanceDimension.Kilometer;
            bool found = kilometer.TryGetCompatibleUnit(CurrentDimension.Units, out CurrentDimension? compatible);
            Assert.IsFalse(found);
            Assert.IsNull(compatible);
        }

        [TestMethod]
        public void TryGetCompatibleUnit_MilliPrefix_FindsMatch()
        {
            VoltageDimension milliVolt = VoltageDimension.MilliVolt;
            bool found = milliVolt.TryGetCompatibleUnit(CurrentDimension.Units, out CurrentDimension? compatible);
            Assert.IsTrue(found);
            Assert.AreEqual(CurrentDimension.MilliAmpere, compatible);
        }
    }
}
