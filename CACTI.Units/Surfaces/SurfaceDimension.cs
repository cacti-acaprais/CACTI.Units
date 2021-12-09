using CACTI.Units.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Surfaces
{
    public class SurfaceDimension : ExponentUnit<DistanceDimension>, IUnit<SurfaceDimension>
    {
        public SurfaceDimension(DistanceDimension dimension) : base(dimension, 2)
        {
        }

        public double ConvertValue(double value, SurfaceDimension unit)
            => base.ConvertValue(value, unit);

        public static SurfaceDimension SquareMeter { get; } = new SurfaceDimension(DistanceDimension.Meter);
        public static SurfaceDimension SquareCentimeter { get; } = new SurfaceDimension(DistanceDimension.Centimeter);

        private static readonly Lazy<SurfaceDimension[]> _lazyUnits = new Lazy<SurfaceDimension[]>(() => CommputeUnits(DistanceDimension.Units).ToArray());
        public static SurfaceDimension[] Units { get; } = new SurfaceDimension[]
        {
            SquareCentimeter,
            SquareMeter
        };

        private static IEnumerable<SurfaceDimension> CommputeUnits(IEnumerable<DistanceDimension> lengthDimensions)
        {
            foreach (DistanceDimension lengthDimension in lengthDimensions)
                yield return new SurfaceDimension(lengthDimension);
        }
    }
}
