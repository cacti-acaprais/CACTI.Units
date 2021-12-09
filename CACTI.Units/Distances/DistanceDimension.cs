using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public class DistanceDimension : Unit<DistanceDimension>
    {
        public DistanceDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static DistanceDimension Kilometer { get; } = new DistanceDimension("km", Kilo);
        public static DistanceDimension Meter { get; } = new DistanceDimension("m", 1);
        public static DistanceDimension Centimeter { get; } = new DistanceDimension("cm", Centi);
        public static DistanceDimension Millimeter { get; } = new DistanceDimension("mm", Milli);

        public static DistanceDimension[] Units { get; } = new DistanceDimension[]
        {
            Millimeter,
            Centimeter,
            Meter,
            Kilometer
        };
    }
}
