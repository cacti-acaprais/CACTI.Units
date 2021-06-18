using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Gram : Mass
    {
        public Gram(double value) : base(value, MassDimension.Gram)
        {
        }

        public static implicit operator Gram(double value)
            => new Gram(value);

        public static Gram Convert(Mass mass)
            => new Gram(mass.Unit.ConvertValue(mass.Value, MassDimension.Gram));
    }
}
