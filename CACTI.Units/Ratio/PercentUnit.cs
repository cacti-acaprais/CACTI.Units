using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class PercentUnit : RatioDimension
    {
        public static PercentUnit Unit { get; } = new PercentUnit();

        public override string Symbol => "%";

        public override double Ratio => 1e-2;
    }
}
