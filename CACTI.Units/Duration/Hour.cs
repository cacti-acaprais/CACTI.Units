using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Hour : Duration
    {
        public Hour(double value) : base(value, DurationDimension.Hour)
        {
        }

        public static implicit operator Hour(double value)
            => new Hour(value);

        public static Hour Convert(Duration duration)
            => new Hour(duration.Unit.ConvertValue(duration.Value, DurationDimension.Hour));
    }
}
