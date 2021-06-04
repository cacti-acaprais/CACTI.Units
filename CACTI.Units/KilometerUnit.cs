using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KilometerUnit : LengthDimension
    {
        public static KilometerUnit Unit { get; } = new KilometerUnit();

        public override string Symbol => "km";

        public override double Ratio => 1e3d;
    }
}
