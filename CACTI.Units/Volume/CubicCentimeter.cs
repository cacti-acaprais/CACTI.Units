using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class CubicCentimeter : Volume
    {
        public CubicCentimeter(double value) : base(value, VolumeDimension.CubicCentimeter)
        {
        }

        public static implicit operator CubicCentimeter(double value)
            => new CubicCentimeter(value);

        public static CubicCentimeter Convert(Volume volume)
            => new CubicCentimeter(volume.Unit.ConvertValue(volume.Value, VolumeDimension.CubicCentimeter));
    }
}
