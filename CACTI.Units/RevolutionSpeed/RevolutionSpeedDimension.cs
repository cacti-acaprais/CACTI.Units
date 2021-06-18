using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CACTI.Units
{
    public class RevolutionSpeedDimension : ComposedUnit<RevolutionDimension, DurationDimension>, IUnit<RevolutionSpeedDimension>
    {
        public RevolutionSpeedDimension(RevolutionDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, RevolutionSpeedDimension unit)
            => base.ConvertValue(value, unit);

        public static RevolutionSpeedDimension RevolutionPerMinute { get; } = new RevolutionSpeedDimension(RevolutionDimension.Revolution, DurationDimension.Minute);
        public static RevolutionSpeedDimension RevolutionPerSecond { get; } = new RevolutionSpeedDimension(RevolutionDimension.Revolution, DurationDimension.Second);

        private static readonly Lazy<RevolutionSpeedDimension[]> _lazyUnits = new Lazy<RevolutionSpeedDimension[]>(() => ComputeUnits(RevolutionDimension.Units, DurationDimension.Units).ToArray());
        public static RevolutionSpeedDimension[] Units => _lazyUnits.Value;
        private static IEnumerable<RevolutionSpeedDimension> ComputeUnits(IEnumerable<RevolutionDimension> revolutionDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (RevolutionDimension revolutionDimension in revolutionDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new RevolutionSpeedDimension(revolutionDimension, durationDimension);
        }
    }
}
