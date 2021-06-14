using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class ForceUnits : IDimensionUnits<ForceDimension>
    {
        public static NewtonUnit Newton => NewtonUnit.Unit;
        public static DynUnit Dyn => DynUnit.Unit;
        public static KilogramForceUnit KilogramForce => KilogramForceUnit.Unit;

        public ForceDimension[] Units { get; } = new ForceDimension[]
        {
            Newton,
            Dyn,
            KilogramForce
        };

        IEnumerable<ForceDimension> IDimensionUnits<ForceDimension>.Units => Units;
    }
}
