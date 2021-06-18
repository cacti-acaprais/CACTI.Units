using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Meter : Length
    {
        public Meter(double value) : base(value, LengthDimension.Meter)
        {
        }

        public static implicit operator Meter(double value)
            => new Meter(value);

        public static Meter Convert(Length length)
            => new Meter(length.Unit.ConvertValue(length.Value, LengthDimension.Meter));
    }
}
