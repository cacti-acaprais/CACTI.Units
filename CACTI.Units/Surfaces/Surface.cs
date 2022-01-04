using CACTI.Units.Distances;
using CACTI.Units.Ratios;
using CACTI.Units.Volumes;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CACTI.Units.Surfaces
{
    public partial class Surface
    {
        public static Volume operator *(Surface surface, Distance length)
            => new Volume(surface.Convert(new SurfaceDimension(length.Unit)).Value * length.Value, new VolumeDimension(length.Unit));
    }
}
