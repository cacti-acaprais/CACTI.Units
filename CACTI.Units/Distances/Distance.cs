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
        {
            Distance convertedLength = length;
            if (!(length.Unit is SIDistanceDimension distanceDimension))
            {
                distanceDimension = SIDistanceDimension.Meter;
                convertedLength = length.Convert(distanceDimension);
            }
                
            return new Speed(convertedLength.Value / duration.Value, new SISpeedDimension(distanceDimension, duration.Unit));
        }
            

        public static Surface operator *(in Distance height, in Distance width)
        {
            if(height.Unit is ImperialDistanceDimension imperialDistanceDimension)
                return new Surface(height.Value * width.ConvertValue(imperialDistanceDimension), new ImperialSurfaceDimension(imperialDistanceDimension));

            if (height.Unit is SIDistanceDimension siDistanceDimension)
                return new Surface(height.Value * width.ConvertValue(siDistanceDimension), new SISurfaceDimension(siDistanceDimension));

            Meter meter = Meter.Convert(height);
            return new Surface(meter.Value * width.ConvertValue(SIDistanceDimension.Meter), new SISurfaceDimension(SIDistanceDimension.Meter));
        }
            
    }
}
