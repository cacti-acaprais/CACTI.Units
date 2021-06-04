using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SpeedDimension : ComposedUnit<LengthDimension, DurationDimension>, IUnit<SpeedDimension>
    {
        public SpeedDimension(LengthDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, SpeedDimension unit)
            => base.ConvertValue(value, unit);
    }
}
