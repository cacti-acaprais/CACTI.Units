using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Revolutions
{
    public class RevolutionDimension : Unit<RevolutionDimension>
    {
        public RevolutionDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static RevolutionDimension Revolution { get; } = new RevolutionDimension("r", 1);

        public static RevolutionDimension[] Units { get; } = new RevolutionDimension[]
        {
            Revolution
        };
    }
}
