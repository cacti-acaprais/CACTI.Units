using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class HourUnit : DurationDimension
    {
        public static HourUnit Unit { get; } = new HourUnit();

        public override string Symbol => "h";

        public override double Ratio => 3600;
    }
}
