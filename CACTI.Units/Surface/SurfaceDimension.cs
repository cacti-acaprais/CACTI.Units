using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SurfaceDimension : ExponentUnit<LengthDimension>, IUnit<SurfaceDimension>
    {
        public SurfaceDimension(LengthDimension dimension) : base(dimension, 2)
        {
        }

        public double ConvertValue(double value, SurfaceDimension unit)
            => base.ConvertValue(value, unit);

        public static SurfaceDimension SquareMeter { get; } = new SurfaceDimension(LengthDimension.Meter);
        public static SurfaceDimension SquareCentimeter { get; } = new SurfaceDimension(LengthDimension.Centimeter);

        private static readonly Lazy<SurfaceDimension[]> _lazyUnits = new Lazy<SurfaceDimension[]>(() => CommputeUnits(LengthDimension.Units).ToArray());
        public static SurfaceDimension[] Units { get; } = new SurfaceDimension[]
        {
            SquareCentimeter,
            SquareMeter
        };

        private static IEnumerable<SurfaceDimension> CommputeUnits(IEnumerable<LengthDimension> lengthDimensions)
        {
            foreach (LengthDimension lengthDimension in lengthDimensions)
                yield return new SurfaceDimension(lengthDimension);
        }
    }
}
