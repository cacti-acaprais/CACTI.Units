using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Surfaces
{
    public class SquareCentimeter : Surface
    {
        public SquareCentimeter(double value) : base(value, SurfaceDimension.SquareCentimeter)
        {
        }

        public static implicit operator SquareCentimeter(double value)
            => new SquareCentimeter(value);

        public static SquareCentimeter Convert(Surface surface)
            => new SquareCentimeter(surface.Unit.ConvertValue(surface.Value, SurfaceDimension.SquareCentimeter));
    }
}
