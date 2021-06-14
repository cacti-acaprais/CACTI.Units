using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Length : UnitValue<LengthDimension, Length>
    {
        public Length(double value, LengthDimension unit) : base(value, unit)
        {
        }

        public override Length Convert(LengthDimension unit)
            => new Length(Unit.ConvertValue(Value, unit), unit);

        public static Length operator +(Length length1, Length length2)
            => new Length(Operation(length1, length2, Addition), length1.Unit);

        public static Length operator -(Length length1, Length length2)
            => new Length(Operation(length1, length2, Substraction), length1.Unit);

        public static Length operator /(Length length, double value)
            => new Length(length.Value / value, length.Unit);

        public static Length operator *(Length length, double value)
            => new Length(length.Value * value, length.Unit);

        public static Ratio operator /(Length length1, Length length2)
            => new Ratio(Operation(length1, length2, Division));

        public static Speed operator /(Length length, Duration duration)
            => new Speed(length.Value / duration.Value, new SpeedDimension(length.Unit, duration.Unit));

        public static SquareMeter operator *(Length heigh, Length width)
        {
            Meter heightMeter = Meter.Convert(heigh);
            Meter withMeter = Meter.Convert(width);

            return new SquareMeter(heightMeter.Value * withMeter.Value);
        }
    }
}
