using CACTI.Units.Accelerations;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Ratios;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Speeds
{
    public partial class Speed
    {
        public static Distance operator *(Speed speed, Duration duration)
        {
            Duration convertedDuration = duration.Convert(speed.Unit.BaseDimension);
            return new Distance(speed.Value * convertedDuration.Value, speed.Unit.Dimension);
        }

        public static Acceleration operator /(Speed speed, Duration duration)
            => new Acceleration(speed.Value / duration.Value, new AccelerationDimension(speed.Unit, duration.Unit));
    }
}
