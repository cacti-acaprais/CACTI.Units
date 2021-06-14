using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class GravityUnits : IDimensionUnits<GravityDimension>
    {
        public static GravityUnit Gravity => GravityUnit.Unit;

        public GravityDimension[] Units { get; } = new GravityDimension[]
        {
            Gravity
        };

        IEnumerable<GravityDimension> IDimensionUnits<GravityDimension>.Units => Units;
    }
}
