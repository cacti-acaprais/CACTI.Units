using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Volume : UnitValue<VolumeDimension, Volume>
    {
        public Volume(double value, VolumeDimension unit) : base(value, unit)
        {
        }

        public override Volume Convert(VolumeDimension unit)
            => new Volume(Unit.ConvertValue(Value, unit), unit);
    }
}
