using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public class Millimeter : Distance
    {
        public Millimeter(double value) : base(value, DistanceDimension.Millimeter)
        {
        }

        public static implicit operator Millimeter(double value)
            => new Millimeter(value);

        public static Millimeter Convert(Distance length)
            => new Millimeter(length.Unit.ConvertValue(length.Value, DistanceDimension.Millimeter));
    }
}
