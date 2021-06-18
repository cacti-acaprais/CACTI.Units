using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Millimeter : Length
    {
        public Millimeter(double value) : base(value, LengthDimension.Millimeter)
        {
        }

        public static implicit operator Millimeter(double value)
            => new Millimeter(value);

        public static Millimeter Convert(Length length)
            => new Millimeter(length.Unit.ConvertValue(length.Value, LengthDimension.Millimeter));
    }
}
