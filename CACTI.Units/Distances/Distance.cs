using CACTI.Units.Durations;
using CACTI.Units.Ratios;
using CACTI.Units.Speeds;
using CACTI.Units.Surfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Distances
{
    public partial class Distance
    {
        public static Speed operator /(Distance length, Duration duration)
            => new Speed(length.Value / duration.Value, new SpeedDimension(length.Unit, duration.Unit));

        public static Surface operator *(Distance heigh, Distance width)
        {
            Distance convertedWith = width.Convert(heigh.Unit);

            return new Surface(heigh.Value * convertedWith.Value, new SurfaceDimension(heigh.Unit));
        }
    }
}
