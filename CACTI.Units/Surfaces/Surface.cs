using CACTI.Units.Distances;
using CACTI.Units.Ratios;
using CACTI.Units.Volumes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Surfaces
{
    public partial class Surface
    {
        public static CubicMeter operator *(Surface surface, Distance length)
        {
            SquareMeter squareMeter = SquareMeter.Convert(surface);
            Meter meter = Meter.Convert(length);

            return new CubicMeter(squareMeter.Value * meter.Value);
        }
    }
}
