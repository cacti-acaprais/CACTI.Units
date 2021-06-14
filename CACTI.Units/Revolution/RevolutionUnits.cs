using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionUnits : IDimensionUnits<RevolutionDimension>
    {
        public static RevolutionUnit Revolution { get; } = RevolutionUnit.Unit;

        public RevolutionDimension[] Units { get; } = new RevolutionDimension[]
        {
            Revolution
        };

        IEnumerable<RevolutionDimension> IDimensionUnits<RevolutionDimension>.Units => Units;
    }
}
