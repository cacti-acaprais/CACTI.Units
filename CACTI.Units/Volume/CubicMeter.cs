using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class CubicMeter : Volume
    {
        public CubicMeter(double value) : base(value, VolumeDimension.CubicMeter)
        {
        }

        public static implicit operator CubicMeter(double value)
            => new CubicMeter(value);

        public static CubicMeter Convert(Volume volume)
            => new CubicMeter(volume.Unit.ConvertValue(volume.Value, VolumeDimension.CubicMeter));
    }
}
