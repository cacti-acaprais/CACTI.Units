using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionUnit : RevolutionDimension
    {
        public static RevolutionUnit Unit { get; } = new RevolutionUnit();

        public override string Symbol => "r";

        public override double Ratio => 1;
    }
}
