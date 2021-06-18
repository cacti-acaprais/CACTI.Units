using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class LengthDimension : Unit<LengthDimension>
    {
        public LengthDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static LengthDimension Kilometer { get; } = new LengthDimension("km", Kilo);
        public static LengthDimension Meter { get; } = new LengthDimension("m", 1);
        public static LengthDimension Centimeter { get; } = new LengthDimension("cm", Centi);
        public static LengthDimension Millimeter { get; } = new LengthDimension("mm", Milli);

        public static LengthDimension[] Units { get; } = new LengthDimension[]
        {
            Millimeter,
            Centimeter,
            Meter,
            Kilometer
        };
    }
}
