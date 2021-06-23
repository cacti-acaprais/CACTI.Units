using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class VolumeDimension : ExponentUnit<LengthDimension>, IUnit<VolumeDimension>
    {
        public VolumeDimension(LengthDimension dimension) : base(dimension, 3)
        {
        }

        public double ConvertValue(double value, VolumeDimension unit)
            => base.ConvertValue(value, unit);

        public static VolumeDimension CubicMeter { get; } = new VolumeDimension(LengthDimension.Meter);
        public static VolumeDimension CubicCentimeter { get; } = new VolumeDimension(LengthDimension.Centimeter);
        //public static VolumeDimension Liter { get; } = new VolumeDimension(LengthDimension.Meter);

        private static readonly Lazy<VolumeDimension[]> _lazyUnits = new Lazy<VolumeDimension[]>(() => ComputeUnits(LengthDimension.Units).ToArray());
        public static VolumeDimension[] Units => _lazyUnits.Value;

        private static IEnumerable<VolumeDimension> ComputeUnits(IEnumerable<LengthDimension> lengthDimensions)
        {
            foreach (LengthDimension lengthDimension in lengthDimensions)
                yield return new VolumeDimension(lengthDimension);
        }
    }
}
