using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Size;

namespace CACTI.Units.Tests
{
    [TestClass]
    public class SizeTests
    {
        [TestMethod]
        public void SizeTest()
        {
            Bytes bytes = 1024;
            KiloBytes kiloBytes = KiloBytes.Convert(bytes);
            Assert.AreEqual("1 Ko", kiloBytes.ToString());

            kiloBytes *= 1024;
            MegaBytes megaBytes = MegaBytes.Convert(kiloBytes);
            Assert.AreEqual("1 Mo", megaBytes.ToString());

            megaBytes *= 1024;
            GigaBytes gigaBytes = GigaBytes.Convert(megaBytes);
            Assert.AreEqual("1 Go", gigaBytes.ToString());

            gigaBytes *= 1024;
            TeraBytes teraBytes = TeraBytes.Convert(gigaBytes);
            Assert.AreEqual("1 To", teraBytes.ToString());
        }
    }
}
