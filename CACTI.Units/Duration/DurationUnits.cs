using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class DurationUnits : IDimensionUnits<DurationDimension>
    {
        public static SecondUnit Second { get; } = SecondUnit.Unit;
        public static MinuteUnit Minute { get; } = MinuteUnit.Unit;
        public static HourUnit Hour { get; } = HourUnit.Unit;

        public DurationDimension[] Units { get; } = new DurationDimension[]
        {
            Second, 
            Minute,
            Hour
        };

        IEnumerable<DurationDimension> IDimensionUnits<DurationDimension>.Units => Units;
    }
}
