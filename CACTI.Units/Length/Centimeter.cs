using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class Centimeter : Length
    {
        public Centimeter(double value) : base(value, LengthDimension.Centimeter)
        {
        }

        public static implicit operator Centimeter(double value)
            => new Centimeter(value);

        public static Centimeter Convert(Length length)
            => new Centimeter(length.Unit.ConvertValue(length.Value, LengthDimension.Centimeter));
    }
}
