using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Dyn : Force
    {
        public Dyn(double value) : base(value, ForceUnits.Dyn)
        {
        }

        public static implicit operator Dyn(double value)
            => new Dyn(value);

        public static Dyn Convert(Force force)
            => new Dyn(force.Unit.ConvertValue(force.Value, ForceUnits.Dyn));
    }
}
