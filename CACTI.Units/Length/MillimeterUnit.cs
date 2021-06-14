using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MillimeterUnit : LengthDimension
    {
        public static MillimeterUnit Unit { get; } = new MillimeterUnit();

        public override string Symbol => "mm";

        public override double Ratio => 1e-3d;
    }
}
