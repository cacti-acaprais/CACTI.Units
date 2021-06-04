using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class CubicMeterUnit : VolumeDimension
    {
        public static CubicMeterUnit Unit { get; } = new CubicMeterUnit();

        public override string Symbol => "m3";

        public override double Ratio => 1;
    }
}
