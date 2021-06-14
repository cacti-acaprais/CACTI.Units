using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RatioUnit : RatioDimension
    {
        public static RatioUnit Unit { get; } = new RatioUnit();

        public override string Symbol => "";

        public override double Ratio => 1;
    }
}
