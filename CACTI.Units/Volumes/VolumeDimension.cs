using CACTI.Units.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Volumes
{
    public class VolumeDimension : ExponentUnit<DistanceDimension>, IUnit<VolumeDimension>
    {
        public VolumeDimension(DistanceDimension dimension) : base(dimension, 3)
        {
        }

        public double ConvertValue(double value, VolumeDimension unit)
            => base.ConvertValue(value, unit);

        public static VolumeDimension CubicMeter { get; } = new VolumeDimension(DistanceDimension.Meter);
        public static VolumeDimension CubicCentimeter { get; } = new VolumeDimension(DistanceDimension.Centimeter);
        //public static VolumeDimension Liter { get; } = new VolumeDimension(LengthDimension.Meter);

        private static readonly Lazy<VolumeDimension[]> _lazyUnits = new Lazy<VolumeDimension[]>(() => ComputeUnits(DistanceDimension.Units).ToArray());
        public static VolumeDimension[] Units => _lazyUnits.Value;

        private static IEnumerable<VolumeDimension> ComputeUnits(IEnumerable<DistanceDimension> lengthDimensions)
        {
            foreach (DistanceDimension lengthDimension in lengthDimensions)
                yield return new VolumeDimension(lengthDimension);
        }
    }
}
