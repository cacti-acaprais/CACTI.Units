using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class MinuteUnit : DurationDimension
    {
        public static MinuteUnit Unit { get; } = new MinuteUnit();

        public override string Symbol => "min";

        public override double Ratio => 60;
    }
}
