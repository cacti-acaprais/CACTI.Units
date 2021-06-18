using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerHour : Speed
    {
        public MeterPerHour(double value) : base(value, SpeedDimension.MeterPerHour)
        {
        }

        public static implicit operator MeterPerHour(double value)
            => new MeterPerHour(value);

        public static MeterPerHour Convert(Speed speed)
            => new MeterPerHour(speed.Unit.ConvertValue(speed.Value, SpeedDimension.MeterPerHour));
    }
}
