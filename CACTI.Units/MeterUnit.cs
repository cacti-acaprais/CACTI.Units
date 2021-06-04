using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MeterUnit : LengthDimension
    {
        public static MeterUnit Unit { get; } = new MeterUnit();

        public override string Symbol => "m";

        public override double Ratio => 1;
    }
}
