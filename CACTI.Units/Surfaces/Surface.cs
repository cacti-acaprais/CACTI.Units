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
            switch (surface.Unit)
            {
                case SISurfaceDimension surfaceDimension:
                    return new Volume(surface.Value * length.ConvertValue(surfaceDimension.Dimension), new SIVolumeDimension(surfaceDimension.Dimension));
                default:
                    return new Volume(surface.ConvertValue(new SISurfaceDimension(length.Unit)) * length.Value, new SIVolumeDimension(length.Unit));
            }
        }
    }
}
