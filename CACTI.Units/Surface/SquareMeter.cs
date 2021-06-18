using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SquareMeter : Surface
    {
        public SquareMeter(double value) : base(value, SurfaceDimension.SquareMeter)
        {
        }

        public static implicit operator SquareMeter(double value)
            => new SquareMeter(value);

        public static SquareMeter Convert(Surface surface)
            => new SquareMeter(surface.Unit.ConvertValue(surface.Value, SurfaceDimension.SquareMeter));
    }
}
