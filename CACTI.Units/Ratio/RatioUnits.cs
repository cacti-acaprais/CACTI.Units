using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RatioUnits : IDimensionUnits<RatioDimension>
    {
        public static RatioUnit Ratio { get; } = RatioUnit.Unit;
        public static PercentUnit Percent { get; } = PercentUnit.Unit;

        public RatioDimension[] Units { get; } = new RatioDimension[]
        {
            Ratio,
            Percent
        };

        IEnumerable<RatioDimension> IDimensionUnits<RatioDimension>.Units => Units;
    }
}
