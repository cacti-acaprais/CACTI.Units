using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class NewtonUnit : ForceDimension
    {
        public static NewtonUnit Unit { get; } = new NewtonUnit();

        public override string Symbol => "N";

        public override double Ratio => 1;
    }
}
