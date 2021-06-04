using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public static class DurationUnits
    {
        public static SecondUnit Second { get; } = SecondUnit.Unit;
        public static MinuteUnit Minute { get; } = MinuteUnit.Unit;
        public static HourUnit Hour { get; } = HourUnit.Unit;
    }
}
