using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Speed : UnitValue<SpeedDimension, Speed>
    {
        public Speed(double value, [NotNull] SpeedDimension unit) : base(value, unit)
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
    }
}
