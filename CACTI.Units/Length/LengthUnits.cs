using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class LengthUnits : IDimensionUnits<LengthDimension>
    {
        public static KilometerUnit Kilometer { get; } = KilometerUnit.Unit;
        public static MeterUnit Meter { get; } = MeterUnit.Unit;
        public static MillimeterUnit Millimeter { get; } = MillimeterUnit.Unit;

        public LengthDimension[] Units { get; } = new LengthDimension[]
        {
            Millimeter,
            Meter,
            Kilometer
        };

        IEnumerable<LengthDimension> IDimensionUnits<LengthDimension>.Units => Units;
    }
}
