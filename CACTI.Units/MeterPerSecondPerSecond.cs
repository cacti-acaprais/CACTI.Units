using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterPerSecondPerSecond : Acceleration
    {
        public MeterPerSecondPerSecond(double value) : base(value, AccelerationUnits.MeterPerSecondPerSecond)
        {
        }

        public static implicit operator MeterPerSecondPerSecond(double value)
            => new MeterPerSecondPerSecond(value);

        public static implicit operator MeterPerSecondPerSecond(Gravity gravity)
            => Convert(gravity);

        public static MeterPerSecondPerSecond Convert(Acceleration acceleration)
            => new MeterPerSecondPerSecond(acceleration.Unit.ConvertValue(acceleration.Value, AccelerationUnits.MeterPerSecondPerSecond));
    }
}
