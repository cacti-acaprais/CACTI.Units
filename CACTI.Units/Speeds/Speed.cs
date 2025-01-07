using CACTI.Units.Ratios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Accelerations;

namespace CACTI.Units.Speeds
{
    public partial class Speed
    {
        public static Distance operator *(in Speed speed, in Duration duration)
            => new Distance(speed.Value * duration.ConvertValue(speed.Unit.BaseDimension), speed.Unit.Dimension);

        public static Acceleration operator /(in Speed speed, in Duration duration)
            => new Acceleration(speed.Value / duration.Value, new AccelerationDimension(speed.Unit, duration.Unit));
    }
}
