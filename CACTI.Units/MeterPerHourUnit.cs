using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerHourUnit : SpeedDimension
    {
        public static MeterPerHourUnit Unit { get; } = new MeterPerHourUnit();

        public MeterPerHourUnit() : base(LengthUnits.Meter, DurationUnits.Hour)
        {
        }
    }
}
