using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionSpeed : UnitValue<RevolutionSpeedDimension, RevolutionSpeed>
    {
        public RevolutionSpeed(double value, RevolutionSpeedDimension unit) : base(value, unit)
        {
        }

        public override RevolutionSpeed Convert(RevolutionSpeedDimension unit)
            => new RevolutionSpeed(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(RevolutionSpeed speed1, RevolutionSpeed speed2)
            => new Ratio(Operation(speed1, speed2, Division));

        public static RevolutionSpeed operator +(RevolutionSpeed speed1, RevolutionSpeed speed2)
            => new RevolutionSpeed(Operation(speed1, speed2, Addition), speed1.Unit);

        public static RevolutionSpeed operator -(RevolutionSpeed speed1, RevolutionSpeed speed2)
            => new RevolutionSpeed(Operation(speed1, speed2, Substraction), speed1.Unit);

        public static RevolutionSpeed operator *(RevolutionSpeed speed, double value)
            => new RevolutionSpeed(speed.Value * value, speed.Unit);

        public static RevolutionSpeed operator /(RevolutionSpeed speed, double value)
            => new RevolutionSpeed(speed.Value / value, speed.Unit);
    }
}
