using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Distances
{
    public class Centimeter : Distance
    {
        public Centimeter(double value) : base(value, DistanceDimension.Centimeter)
        {
        }

        public static implicit operator Centimeter(double value)
            => new Centimeter(value);

        public static Centimeter Convert(Distance length)
            => new Centimeter(length.Unit.ConvertValue(length.Value, DistanceDimension.Centimeter));
    }
}
