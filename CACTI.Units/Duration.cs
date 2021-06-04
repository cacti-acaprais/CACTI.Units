using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Duration : UnitValue<DurationDimension, Duration>
    {
        public Duration(double value, [NotNull] DurationDimension unit) : base(value, unit)
        {
        }

        public override Duration Convert(DurationDimension unit)
            => new Duration(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Duration duration1, Duration duration2)
            => new Ratio(Operation(duration1, duration2, Division));

        public static Duration operator *(Duration duration, double value)
            => new Duration(duration.Value * value, duration.Unit);

        public static Duration operator /(Duration duration, double value)
            => new Duration(duration.Value / value, duration.Unit);

        public static Duration operator +(Duration duration1, Duration duration2)
            => new Duration(Operation(duration1, duration2, Addition), duration1.Unit);

        public static Duration operator -(Duration duration1, Duration duration2)
            => new Duration(Operation(duration1, duration2, Substraction), duration1.Unit);
    }
}
