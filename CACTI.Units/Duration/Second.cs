using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Second : Duration
    {
        public Second(double value) : base(value, DurationDimension.Second)
        {
        }

        public static implicit operator Second(double value)
            => new Second(value);

        public static Second Convert(Duration duration)
            => new Second(duration.Unit.ConvertValue(duration.Value, DurationDimension.Second));
    }
}
