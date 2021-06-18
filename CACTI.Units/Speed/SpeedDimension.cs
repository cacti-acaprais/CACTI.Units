using System;
using System.Collections.Generic;
using System.Linq;

namespace CACTI.Units
{
    public class SpeedDimension : ComposedUnit<LengthDimension, DurationDimension>, IUnit<SpeedDimension>
    {
        public SpeedDimension(LengthDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, SpeedDimension unit)
            => base.ConvertValue(value, unit);

        public static SpeedDimension MeterPerSecond { get; } = new SpeedDimension(LengthDimension.Meter, DurationDimension.Second);
        public static SpeedDimension MeterPerHour { get; } = new SpeedDimension(LengthDimension.Meter, DurationDimension.Hour);
        public static SpeedDimension KilometerPerHour { get; } = new SpeedDimension(LengthDimension.Kilometer, DurationDimension.Hour);

        private static Lazy<SpeedDimension[]> _lazyUnits = new Lazy<SpeedDimension[]>(() => ComputeUnits(LengthDimension.Units, DurationDimension.Units).ToArray());
        public static SpeedDimension[] Units => _lazyUnits.Value;

        private static IEnumerable<SpeedDimension> ComputeUnits(IEnumerable<LengthDimension> lengthDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (LengthDimension lengthDimension in lengthDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new SpeedDimension(lengthDimension, durationDimension);
        }
    }
}
