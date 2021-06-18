using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class GravityDimension : Unit<GravityDimension>
    {
        protected GravityDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static GravityDimension Gravity { get; } = new GravityDimension("G", 1);

        public static GravityDimension[] Units { get; } = new GravityDimension[]
        {
            Gravity
        };
    }
}
