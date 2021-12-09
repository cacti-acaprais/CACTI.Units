using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Masses
{
    public class MassDimension : Unit<MassDimension>
    {
        public MassDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static MassDimension Kilogram { get; } = new MassDimension("kg", Kilo);
        public static MassDimension Gram { get; } = new MassDimension("g", 1);

        public static MassDimension[] Units { get; } = new MassDimension[]
        {
            Gram,
            Kilogram
        };
    }
}
