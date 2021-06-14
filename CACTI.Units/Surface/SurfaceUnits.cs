using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SurfaceUnits : IDimensionUnits<SurfaceDimension>
    {
        public static SquareMeterUnit SquareMeter { get; } = SquareMeterUnit.Unit;

        public SurfaceDimension[] Units { get; } = new SurfaceDimension[]
        {
            SquareMeter
        };

        IEnumerable<SurfaceDimension> IDimensionUnits<SurfaceDimension>.Units => Units;
    }
}
