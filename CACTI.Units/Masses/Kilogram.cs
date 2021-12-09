using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Masses
{
    public class Kilogram : Mass
    {
        public Kilogram(double value) : base(value, MassDimension.Kilogram)
        {
        }

        public static implicit operator Kilogram(double value)
            => new Kilogram(value);

        public static Kilogram Convert(Mass mass)
            => new Kilogram(mass.Unit.ConvertValue(mass.Value, MassDimension.Kilogram));
    }
}
