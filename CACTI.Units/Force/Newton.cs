using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Newton : Force
    {
        public Newton(double value) : base(value, ForceDimension.Newton)
        {
        }

        public static implicit operator Newton(double value)
            => new Newton(value);

        public static Newton Convert(Force force)
            => new Newton(force.Unit.ConvertValue(force.Value, ForceDimension.Newton));
    }
}
