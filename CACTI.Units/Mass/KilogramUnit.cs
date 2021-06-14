using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KilogramUnit : MassDimension
    {
        public static KilogramUnit Unit { get; } = new KilogramUnit();

        public override string Symbol => "kg";

        public override double Ratio => 1;
    }
}
