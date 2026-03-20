using CACTI.Units.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Volumes;

namespace CACTI.Units.Surfaces
{
    public partial class Surface
    {
        public static Volume operator *(in Surface surface, in Distance length)
        {
            if(surface.Unit is SISurfaceDimension surfaceDimension)
                return new Volume(surface.Value * length.ConvertValue(surfaceDimension.Dimension), new SIVolumeDimension(surfaceDimension.Dimension));

            if (length.Unit is SIDistanceDimension distanceDimention)
                return new Volume(surface.ConvertValue(new SISurfaceDimension(distanceDimention)) * length.Value, new SIVolumeDimension(distanceDimention));

            Meter meter = Meter.Convert(length);
            return new Volume(surface.ConvertValue(new SISurfaceDimension(SIDistanceDimension.Meter)) * meter.Value, new SIVolumeDimension(SIDistanceDimension.Meter));
        }
    }
}
