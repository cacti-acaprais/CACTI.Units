using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerSecondUnit : SpeedDimension
    {
        public static MeterPerSecondUnit Unit { get; } = new MeterPerSecondUnit();

        public MeterPerSecondUnit() : base(LengthUnits.Meter, DurationUnits.Second)
        {
        }
    }
}
