using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public class Kilometer : Distance
    {
        public Kilometer(double value) : base(value, DistanceDimension.Kilometer)
        {
        }

        public static implicit operator Kilometer(double value)
            => new Kilometer(value);

        public static Kilometer Convert(Distance length)
            => new Kilometer(length.Unit.ConvertValue(length.Value, DistanceDimension.Kilometer));
    }
}
