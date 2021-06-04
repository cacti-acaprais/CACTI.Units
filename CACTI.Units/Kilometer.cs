using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Kilometer : Length
    {
        public Kilometer(double value) : base(value, LengthUnits.Kilometer)
        {
        }

        public static implicit operator Kilometer(double value)
            => new Kilometer(value);

        public static Kilometer Convert(Length length)
            => new Kilometer(length.Unit.ConvertValue(length.Value, LengthUnits.Kilometer));
    }
}
