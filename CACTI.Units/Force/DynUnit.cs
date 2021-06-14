using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class DynUnit : ForceDimension
    {
        public static DynUnit Unit { get; } = new DynUnit();

        public override string Symbol => "dyn";

        public override double Ratio => 1e-5d;
    }
}
