using CACTI.Units.Distances;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Surfaces
{
    public class SquareCentimeterUnit : SurfaceDimension
    {
        public static SquareCentimeterUnit Unit { get; } = new SquareCentimeterUnit();

        public SquareCentimeterUnit() : base(DistanceDimension.Centimeter)
        {
        }
    }
}
