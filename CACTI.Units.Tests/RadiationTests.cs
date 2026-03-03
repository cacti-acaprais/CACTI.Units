using CACTI.Units.Radiations;
using CACTI.Units.Ratios;
using CACTI.Units.Durations;
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
    public class RadiationTests
    {
        [TestMethod]
        public void RadiationTest()
        {
            Sievert sievert = 10;

            Dose millirem1 = (Millirem)sievert;
            Dose sievertDose = sievert;

            Sievert add = sievert + (Percent)10;
            Dose m = sievert.Convert(DoseDimension.Decarem);


            DoseDimension decirem = DoseDimension.Decirem;
            Dose microsievert = sievert.Convert(decirem);

            Assert.AreEqual("10 Sv", sievert.ToString());
            Hour hour = 5;
            Rate rate = sievert / hour;
            Assert.AreEqual("2 Sv/h", rate.ToString());

            MillisievertPerSecond millisievertPerSecond = SievertPerMinute.Convert(rate);
            Assert.AreEqual("0.56 mSv/s", millisievertPerSecond.ToString("F2", CultureInfo.InvariantCulture));

            Dose dose = rate * (Hour)3;
            Assert.AreEqual("6 Sv", dose.ToString());
            Millirem millirem = Millirem.Convert(dose);
            Assert.AreEqual("600000 mrem", millirem.ToString());

            CentiGray centiGray = CentiGray.Convert(dose);
            Assert.AreEqual("600 cGy", centiGray.ToString());
        }
    }
}
