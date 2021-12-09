using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Forces
{
    public class KilogramForce : Force
    {
        public KilogramForce(double value) : base(value, ForceDimension.KilogramForce)
        {
        }

        public static implicit operator KilogramForce(double value)
            => new KilogramForce(value);

        public static KilogramForce Convert(Force force)
            => new KilogramForce(force.Unit.ConvertValue(force.Value, ForceDimension.KilogramForce));
    }
}
