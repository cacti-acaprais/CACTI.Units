using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Durations
{
    public class DurationDimension : Unit<DurationDimension>
    {
        public DurationDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static DurationDimension Second { get; } = new DurationDimension("s", 1);
        public static DurationDimension Minute { get; } = new DurationDimension("m", 60);
        public static DurationDimension Hour { get; } = new DurationDimension("h", 3600);

        public static IEnumerable<DurationDimension> Units 
        { 
            get
            {
                yield return Second;
                yield return Minute;
                yield return Hour;
            }
        }
    }
}
