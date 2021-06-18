using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class ForceDimension : Unit<ForceDimension>
    {
        public ForceDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static ForceDimension Newton => new ForceDimension("N", 1);
        public static ForceDimension Dyn => new ForceDimension("dyn", 1e-5d);
        public static ForceDimension KilogramForce => new ForceDimension("kgf", 9.80665);

        public static ForceDimension[] Units { get; } = new ForceDimension[]
        {
            Newton,
            Dyn,
            KilogramForce
        };
    }
}
