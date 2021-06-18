using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RatioDimension : Unit<RatioDimension>
    {
        public RatioDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static RatioDimension RatioUnit { get; } = new RatioDimension("", 1);
        public static RatioDimension Percent { get; } = new RatioDimension("%", 1e-2);

        public RatioDimension[] Units { get; } = new RatioDimension[]
        {
            RatioUnit,
            Percent
        };
    }
}
