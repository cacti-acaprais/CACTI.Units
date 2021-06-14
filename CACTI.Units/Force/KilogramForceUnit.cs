using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KilogramForceUnit : ForceDimension
    {
        public static KilogramForceUnit Unit { get; } = new KilogramForceUnit();

        public override string Symbol => "kgf";

        public override double Ratio => 9.80665;
    }
}
