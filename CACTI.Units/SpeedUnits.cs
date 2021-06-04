using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public static class SpeedUnits
    {
        public static MeterPerSecondUnit MeterPerSecond { get; } = MeterPerSecondUnit.Unit;
        public static MeterPerHourUnit MeterPerHour { get; } = MeterPerHourUnit.Unit;
        public static KilometerPerHourUnit KilometerPerHour { get; } = KilometerPerHourUnit.Unit;
    }
}
