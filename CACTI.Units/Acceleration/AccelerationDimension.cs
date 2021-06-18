using System;
using System.Collections.Generic;
using System.Linq;

namespace CACTI.Units
{
    public class AccelerationDimension : ComposedUnit<SpeedDimension, DurationDimension>, IUnit<AccelerationDimension>
    {
        public AccelerationDimension(SpeedDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, AccelerationDimension unit)
            => base.ConvertValue(value, unit);

        public static AccelerationDimension MeterPerSecondPerSecond => new AccelerationDimension(SpeedDimension.MeterPerSecond, DurationDimension.Second);

        private static readonly Lazy<AccelerationDimension[]> _lazyUnits = new Lazy<AccelerationDimension[]>(() => ComputeUnits(SpeedDimension.Units, DurationDimension.Units).ToArray());
        public static AccelerationDimension[] Units => _lazyUnits.Value;

        private static IEnumerable<AccelerationDimension> ComputeUnits(IEnumerable<SpeedDimension> speedDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (SpeedDimension speedDimension in speedDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new AccelerationDimension(speedDimension, durationDimension);
        }
    }
}
