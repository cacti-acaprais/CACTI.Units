using CACTI.Units.Durations;
using CACTI.Units.Ratios;
using CACTI.Units.Speeds;
using CACTI.Units.Surfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public class Distance : UnitValue<DistanceDimension, Distance>
    {
        public Distance(double value, DistanceDimension unit) : base(value, unit)
        {
        }

        public override Distance Convert(DistanceDimension unit)
            => new Distance(Unit.ConvertValue(Value, unit), unit);

        public static Distance operator +(Distance length1, Distance length2)
            => new Distance(Operation(length1, length2, Addition), length1.Unit);

        public static Distance operator -(Distance length1, Distance length2)
            => new Distance(Operation(length1, length2, Substraction), length1.Unit);

        public static Distance operator /(Distance length, double value)
            => new Distance(length.Value / value, length.Unit);

        public static Distance operator *(Distance length, double value)
            => new Distance(length.Value * value, length.Unit);

        public static Ratio operator /(Distance length1, Distance length2)
            => new Ratio(Operation(length1, length2, Division));

        public static Speed operator /(Distance length, Duration duration)
            => new Speed(length.Value / duration.Value, new SpeedDimension(length.Unit, duration.Unit));

        public static Surface operator *(Distance heigh, Distance width)
        {
            Distance convertedWith = width.Convert(heigh.Unit);

            return new Surface(heigh.Value * convertedWith.Value, new SurfaceDimension(heigh.Unit));
        }

        public static bool TryParse(string valueString, [MaybeNull][NotNullWhen(true)] out Distance distance)
            => TryParse(valueString, null, out distance);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [MaybeNull][NotNullWhen(true)] out Distance distance)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            distance = default;

            if (!UnitValueParser.TryParse<DistanceDimension, Distance>(valueString, DistanceDimension.Units, formatProvider, out double value, out DistanceDimension? unit))
                return false;

            distance = new Distance(value, unit);
            return true;
        }
    }
}
