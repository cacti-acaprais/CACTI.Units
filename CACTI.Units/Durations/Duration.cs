using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Durations
{
    public partial class Duration
    {
        public static TimeSpan ToTimeSpan(Duration duration)
            => TimeSpan.FromSeconds(duration.ConvertValue(DurationDimension.Second));
    }
}
