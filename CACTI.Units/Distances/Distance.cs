using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Speeds;
using CACTI.Units.Durations;
using CACTI.Units.Surfaces;

namespace CACTI.Units.Distances
{
    public partial class Distance
    {
        public static Speed operator /(in Distance length, in Duration duration)
            => new Speed(length.Value / duration.Value, new SpeedDimension(length.Unit, duration.Unit));

        public static Surface operator *(in Distance heigh, in Distance width)
            => new Surface(heigh.Value * width.ConvertValue(heigh.Unit), new SISurfaceDimension(heigh.Unit));
    }
}
