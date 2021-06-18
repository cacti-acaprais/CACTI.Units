using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class SquareCentimeterUnit : SurfaceDimension
    {
        public static SquareCentimeterUnit Unit { get; } = new SquareCentimeterUnit();

        public SquareCentimeterUnit() : base(LengthDimension.Centimeter)
        {
        }
    }
}
