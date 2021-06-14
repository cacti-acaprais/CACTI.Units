using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SecondUnit : DurationDimension
    {
        public static SecondUnit Unit { get; } = new SecondUnit();

        public override string Symbol => "s";

        public override double Ratio => 1;
    }
}
