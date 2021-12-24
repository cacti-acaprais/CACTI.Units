using CACTI.Units.Accelerations;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Ratios;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Speeds
{
    public class Speed : UnitValue<SpeedDimension, Speed>
    {
        public Speed(double value, SpeedDimension unit) : base(value, unit)
        {
        }

        public override Speed Convert(SpeedDimension unit)
            => new Speed(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Speed speed1, Speed speed2)
            => new Ratio(Operation(speed1, speed2, Division));

        public static Speed operator +(Speed speed1, Speed speed2)
            => new Speed(Operation(speed1, speed2, Addition), speed1.Unit);

        public static Speed operator -(Speed speed1, Speed speed2)
            => new Speed(Operation(speed1, speed2, Substraction), speed1.Unit);

        public static Speed operator *(Speed speed, double value)
            => new Speed(speed.Value * value, speed.Unit);

        public static Speed operator /(Speed speed, double value)
            => new Speed(speed.Value / value, speed.Unit);

        public static Distance operator *(Speed speed, Duration duration)
        {
            Duration convertedDuration = duration.Convert(speed.Unit.BaseDimension);
            return new Distance(speed.Value * convertedDuration.Value, speed.Unit.Dimension);
        }

        public static Acceleration operator /(Speed speed, Duration duration)
            => new Acceleration(speed.Value / duration.Value, new AccelerationDimension(speed.Unit, duration.Unit));

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Speed? speed)
            => TryParse(valueString, null, out speed);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Speed? speed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            speed = default;

            if (!UnitValueParser.TryParse<SpeedDimension, Speed>(valueString, SpeedDimension.Units, formatProvider, out double value, out SpeedDimension? unit))
                return false;

            speed = new Speed(value, unit);
            return true;
        }
    }
}
