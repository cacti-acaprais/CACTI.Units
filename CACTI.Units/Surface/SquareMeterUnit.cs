using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SquareMeterUnit : SurfaceDimension
    {
        public static SquareMeterUnit Unit { get; } = new SquareMeterUnit();

        public override string Symbol => "m²";

        public override double Ratio => 1;
    }
}
