using CACTI.Units.Distances;
using CACTI.Units.Durations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CACTI.Units.Speeds
{
    public class SpeedDimension : ComposedUnit<DistanceDimension, DurationDimension>, IUnit<SpeedDimension>
    {
        public SpeedDimension(DistanceDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, SpeedDimension unit)
            => base.ConvertValue(value, unit);

        public static SpeedDimension MeterPerSecond { get; } = new SpeedDimension(DistanceDimension.Meter, DurationDimension.Second);
        public static SpeedDimension MeterPerHour { get; } = new SpeedDimension(DistanceDimension.Meter, DurationDimension.Hour);
        public static SpeedDimension KilometerPerHour { get; } = new SpeedDimension(DistanceDimension.Kilometer, DurationDimension.Hour);

        private static Lazy<SpeedDimension[]> _lazyUnits = new Lazy<SpeedDimension[]>(() => ComputeUnits(DistanceDimension.Units, DurationDimension.Units).ToArray());
        public static SpeedDimension[] Units => _lazyUnits.Value;

        private static IEnumerable<SpeedDimension> ComputeUnits(IEnumerable<DistanceDimension> lengthDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (DistanceDimension lengthDimension in lengthDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new SpeedDimension(lengthDimension, durationDimension);
        }
    }
}
