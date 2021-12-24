using CACTI.Units.Distances;
using CACTI.Units.Ratios;
using CACTI.Units.Volumes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Surfaces
{
    public class Surface : UnitValue<SurfaceDimension, Surface>
    {
        public Surface(double value, SurfaceDimension unit) : base(value, unit)
        {
        }

        public override Surface Convert(SurfaceDimension unit)
            => new Surface(Unit.ConvertValue(Value, unit), unit);

        public static CubicMeter operator *(Surface surface, Distance length)
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

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Surface? parsed)
            => TryParse(valueString, null, out parsed);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Surface? parsed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsed = default;

            if (!UnitValueParser.TryParse<SurfaceDimension, Surface>(valueString, SurfaceDimension.Units, formatProvider, out double value, out SurfaceDimension? unit))
                return false;

            parsed = new Surface(value, unit);
            return true;
        }
    }
}
