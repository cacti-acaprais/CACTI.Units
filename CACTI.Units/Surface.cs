using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Surface : UnitValue<SurfaceDimension, Surface>
    {
        public Surface(double value, [NotNull] SurfaceDimension unit) : base(value, unit)
        {
        }

        public override Surface Convert(SurfaceDimension unit)
            => new Surface(Unit.ConvertValue(Value, unit), unit);

        public static CubicMeter operator *(Surface surface, Length length)
        {
            SquareMeter squareMeter = SquareMeter.Convert(surface);
            Meter meter = Meter.Convert(length);

            return new CubicMeter(squareMeter.Value * meter.Value);
        }

        public static Ratio operator /(Surface surface1, Surface surface2)
            => new Ratio(Operation(surface1, surface2, Division));

        public static Surface operator /(Surface surface, double value)
            => new Surface(surface.Value / value, surface.Unit);

        public static Surface operator *(Surface surface, double value)
            => new Surface(surface.Value * value, surface.Unit);

        public static Surface operator +(Surface surface1, Surface surface2)
            => new Surface(Operation(surface1, surface2, Addition), surface1.Unit);

        public static Surface operator -(Surface surface1, Surface surface2)
            => new Surface(Operation(surface1, surface2, Substraction), surface1.Unit);
    }
}
