using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MassUnits : IDimensionUnits<MassDimension>
    {
        public static KilogramUnit Kilogram => KilogramUnit.Unit;
        public static GramUnit Gram => GramUnit.Unit;

        public MassDimension[] Units { get; } = new MassDimension[]
        {
            Gram,
            Kilogram
        };

        IEnumerable<MassDimension> IDimensionUnits<MassDimension>.Units => Units;
    }
}
