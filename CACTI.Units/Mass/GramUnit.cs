using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class GramUnit : MassDimension
    {
        public static GramUnit Unit { get; } = new GramUnit();

        public override string Symbol => "g";

        public override double Ratio => 1e-3d;
    }
}
