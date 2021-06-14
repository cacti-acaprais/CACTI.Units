using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class VolumeUnits : IDimensionUnits<VolumeDimension>
    {
        public static CubicMeterUnit CubicMeter { get; } = CubicMeterUnit.Unit;

        public VolumeDimension[] Units { get; } = new VolumeDimension[]
        {
            CubicMeter
        };

        IEnumerable<VolumeDimension> IDimensionUnits<VolumeDimension>.Units => Units;
    }
}
