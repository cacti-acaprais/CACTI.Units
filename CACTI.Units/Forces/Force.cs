using CACTI.Units.Accelerations;
using CACTI.Units.Masses;
using CACTI.Units.Ratios;
using System;

namespace CACTI.Units.Forces
{
    public class Force : UnitValue<ForceDimension, Force>
    {
        public Force(double value, ForceDimension unit) : base(value, unit)
        {
        }

        public override Force Convert(ForceDimension unit)
            => new Force(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Force force1, Force force2)
            => new Ratio(Operation(force1, force2, Division));

        public static Force operator *(Force force, double value)
            => new Force(force.Value * value, force.Unit);

        public static Force operator /(Force force, double value)
            => new Force(force.Value / value, force.Unit);

        public static Force operator +(Force force1, Force force2)
            => new Force(Operation(force1, force2, Addition), force1.Unit);

        public static Force operator -(Force force1, Force force2)
            => new Force(Operation(force1, force2, Substraction), force1.Unit);

        public static MeterPerSecondPerSecond operator /(Force force, Mass mass)
        {
            Newton newton = Newton.Convert(force);
            Kilogram kilogram = Kilogram.Convert(mass);

            return newton.Value / kilogram.Value;
        }

        public static bool TryParse(string valueString, out Force parsed)
           => TryParse(valueString, null, out parsed);

        public static bool TryParse(string valueString, IFormatProvider formatProvider, out Force parsed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsed = default;

            if (!UnitValueParser.TryParse<ForceDimension, Force>(valueString, ForceDimension.Units, formatProvider, out double value, out ForceDimension unit))
                return false;

            parsed = new Force(value, unit);
            return true;
        }
    }
}
