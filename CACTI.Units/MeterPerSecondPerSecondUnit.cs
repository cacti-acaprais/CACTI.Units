using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerSecondPerSecondUnit : AccelerationDimension
    {
        public static MeterPerSecondPerSecondUnit Unit { get; } = new MeterPerSecondPerSecondUnit();

        public MeterPerSecondPerSecondUnit() : base(SpeedUnits.MeterPerSecond, DurationUnits.Second)
        {
        }
    }
}
