using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Gravity : UnitValue<GravityDimension, Gravity>
    {
        public Gravity(double value) : base(value, GravityUnits.Gravity)
        {

        }

        public Gravity(double value, GravityDimension unit) : base(value, unit)
        {
        }

        public override Gravity Convert(GravityDimension unit)
            => new Gravity(Unit.ConvertValue(Value, unit), unit);

        public static implicit operator Gravity(double value)
            => new Gravity(value);

        public static Gravity Convert(Acceleration acceleration)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            return meterPerSecondPerSecond.Value / ForceUnits.KilogramForce.Ratio;
        }

        public static implicit operator Gravity(Acceleration acceleration)
            => Convert(acceleration);

        public static Ratio operator /(Gravity gravity1, Gravity gravity2)
            => new Ratio(Operation(gravity1, gravity2, Division));

        public static Gravity operator *(Gravity gravity, double value)
            => new Gravity(gravity.Value * value, gravity.Unit);

        public static Gravity operator /(Gravity gravity, double value)
            => new Gravity(gravity.Value / value, gravity.Unit);

        public static Gravity operator +(Gravity gravity1, Gravity gravity2)
            => new Gravity(Operation(gravity1, gravity2, Addition), gravity1.Unit);

        public static Gravity operator -(Gravity gravity1, Gravity gravity2)
            => new Gravity(Operation(gravity1, gravity2, Substraction), gravity1.Unit);
    }
}
