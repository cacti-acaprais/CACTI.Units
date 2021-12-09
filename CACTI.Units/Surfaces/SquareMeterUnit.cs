using CACTI.Units.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Surfaces
{
    public class SquareMeterUnit : SurfaceDimension
    {
        public static SquareMeterUnit Unit { get; } = new SquareMeterUnit();

        public SquareMeterUnit() : base(DistanceDimension.Meter)
        {
        }

        
    }
}
