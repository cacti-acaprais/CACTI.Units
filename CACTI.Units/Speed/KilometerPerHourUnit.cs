using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KilometerPerHourUnit : SpeedDimension
    {
        public static KilometerPerHourUnit Unit { get; } = new KilometerPerHourUnit();

        public KilometerPerHourUnit() : base(LengthUnits.Kilometer, DurationUnits.Hour)
        {
        }
    }
}
