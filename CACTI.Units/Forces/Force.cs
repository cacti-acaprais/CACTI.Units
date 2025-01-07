using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Accelerations;
using CACTI.Units.Masses;

namespace CACTI.Units.Forces
{
    public partial class Force
    {
        public static MeterPerSecondPerSecond operator /(in Force force, in Mass mass)
            => force.ConvertValue(ForceDimension.Newton) / mass.ConvertValue(MassDimension.Kilogram);
    }
}
