using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public class Meter : Distance
    {
        public Meter(double value) : base(value, DistanceDimension.Meter)
        {
        }

        public static implicit operator Meter(double value)
            => new Meter(value);

        public static Meter Convert(Distance length)
            => new Meter(length.Unit.ConvertValue(length.Value, DistanceDimension.Meter));
    }
}
