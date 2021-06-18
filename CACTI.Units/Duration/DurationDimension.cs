using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class DurationDimension : Unit<DurationDimension>
    {
        public DurationDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static DurationDimension Second { get; } = new DurationDimension("s", 1);
        public static DurationDimension Minute { get; } = new DurationDimension("m", 60);
        public static DurationDimension Hour { get; } = new DurationDimension("h", 3600);

        public static DurationDimension[] Units { get; } = new DurationDimension[]
        {
            Second,
            Minute,
            Hour
        };
    }
}
