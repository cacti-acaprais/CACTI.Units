using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerSecond : Speed
    {
        public MeterPerSecond(double value) : base(value, SpeedUnits.MeterPerSecond)
        {
        }

        public static implicit operator MeterPerSecond(double value)
            => new MeterPerSecond(value);

        public static MeterPerSecond Convert(Speed speed)
            => new MeterPerSecond(speed.Unit.ConvertValue(speed.Value, SpeedUnits.MeterPerSecond));
    }
}
