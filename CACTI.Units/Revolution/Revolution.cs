using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Revolution : UnitValue<RevolutionDimension, Revolution>
    {
        public Revolution(double value) : this(value, RevolutionUnits.Revolution)
        {

        }

        public Revolution(double value, RevolutionDimension unit) : base(value, unit)
        {
        }

        public override Revolution Convert(RevolutionDimension unit)
             => new Revolution(Unit.ConvertValue(Value, unit), unit);

        public static Revolution Convert(Revolution revolution)
            => new Revolution(revolution.Unit.ConvertValue(revolution.Value, RevolutionUnits.Revolution));

        public static implicit operator Revolution(double value)
            => new Revolution(value);

        public static Ratio operator /(Revolution revolution1, Revolution revolution2)
            => new Ratio(Operation(revolution1, revolution2, Division));

        public static Revolution operator +(Revolution revolution1, Revolution revolution2)
            => new Revolution(Operation(revolution1, revolution2, Addition), revolution1.Unit);

        public static Revolution operator -(Revolution revolution1, Revolution revolution2)
            => new Revolution(Operation(revolution1, revolution2, Substraction), revolution1.Unit);

        public static Revolution operator /(Revolution revolution, double value)
            => new Revolution(revolution.Value / value, revolution.Unit);

        public static Revolution operator *(Revolution revolution, double value)
            => new Revolution(revolution.Value * value, revolution.Unit);

        public static RevolutionSpeed operator /(Revolution revolution, Duration duration)
            => new RevolutionSpeed(revolution.Value / duration.Value, new RevolutionSpeedDimension(revolution.Unit, duration.Unit));
    }
}
