using CACTI.Units.Accelerations;
using CACTI.Units.Forces;
using CACTI.Units.Ratios;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Gravities
{
    public class Gravity : UnitValue<GravityDimension, Gravity>
    {
        public Gravity(double value) : base(value, GravityDimension.Gravity)
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
            double gravityValue = meterPerSecondPerSecond.Value / ForceDimension.KilogramForce.Ratio;
            return gravityValue;
        }

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

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Gravity? parsed)
            => TryParse(valueString, null, out parsed);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Gravity? parsed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsed = default;

            if (!UnitValueParser.TryParse<GravityDimension, Gravity>(valueString, GravityDimension.Units, formatProvider, out double value, out GravityDimension? unit))
                return false;

            parsed = new Gravity(value, unit);
            return true;
        }
    }
}
