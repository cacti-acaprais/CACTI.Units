using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Minute : Duration
    {
        public Minute(double value) : base(value, DurationDimension.Minute)
        {
        }

        public static implicit operator Minute(double value)
            => new Minute(value);

        public static Minute Convert(Duration duration)
            => new Minute(duration.Unit.ConvertValue(duration.Value, DurationDimension.Minute));
    }
}
