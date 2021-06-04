using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionSpeedDimension : ComposedUnit<RevolutionDimension, DurationDimension>, IUnit<RevolutionSpeedDimension>
    {
        public RevolutionSpeedDimension([NotNull] RevolutionDimension dimension, [NotNull] DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, RevolutionSpeedDimension unit)
            => base.ConvertValue(value, unit);
    }
}
