using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class GravityUnit : GravityDimension
    {
        public static GravityUnit Unit { get; } = new GravityUnit();

        public override string Symbol => "g";

        public override double Ratio => 1;
    }
}
