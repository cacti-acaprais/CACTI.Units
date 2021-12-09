using CACTI.Units.Forces;
using CACTI.Units.Gravities;
using CACTI.Units.Masses;
using CACTI.Units.Ratios;
using System;

namespace CACTI.Units.Accelerations
{
    public class Acceleration : UnitValue<AccelerationDimension, Acceleration>
    {
        public Acceleration(double value, AccelerationDimension unit) : base(value, unit)
        {
        }

        public override Acceleration Convert(AccelerationDimension unit)
            => new Acceleration(Unit.ConvertValue(Value, unit), unit);

        public static MeterPerSecondPerSecond Convert(Gravity gravity)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = gravity.Value / ForceDimension.KilogramForce.Ratio;
            return meterPerSecondPerSecond;
        }

        public static implicit operator Acceleration(Gravity gravity)
            => Convert(gravity);

        public static Ratio operator /(Acceleration acceleration1, Acceleration acceleration2)
            => new Ratio(Operation(acceleration1, acceleration2, Division));

        public static Acceleration operator *(Acceleration acceleration, double value)
            => new Acceleration(acceleration.Value * value, acceleration.Unit);

        public static Acceleration operator /(Acceleration acceleration, double value)
            => new Acceleration(acceleration.Value / value, acceleration.Unit);

        public static Acceleration operator +(Acceleration acceleration1, Acceleration acceleration2)
            => new Acceleration(Operation(acceleration1, acceleration2, Addition), acceleration1.Unit);

        public static Acceleration operator -(Acceleration acceleration1, Acceleration acceleration2)
            => new Acceleration(Operation(acceleration1, acceleration2, Substraction), acceleration1.Unit);

        public static Newton operator *(Mass mass, Acceleration acceleration)
            => acceleration * mass;

        public static Newton operator *(Acceleration acceleration, Mass mass)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Kilogram kilogram = Kilogram.Convert(mass);

            return meterPerSecondPerSecond.Value * kilogram.Value;
        }

        public static bool TryParse(string valueString, out Acceleration parsed)
            => TryParse(valueString, null, out parsed);

        public static bool TryParse(string valueString, IFormatProvider formatProvider, out Acceleration parsed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsed = default;

            if (!UnitValueParser.TryParse<AccelerationDimension, Acceleration>(valueString, AccelerationDimension.Units, formatProvider, out double value, out AccelerationDimension unit))
                return false;

            parsed = new Acceleration(value, unit);
            return true;
        }
    }
}
