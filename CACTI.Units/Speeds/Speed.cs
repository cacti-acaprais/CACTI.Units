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
        {
            if(speed.Unit is SISpeedDimension speedDimension)
                return new Distance(speed.Value * duration.ConvertValue(speedDimension.BaseDimension), speedDimension.Dimension);

            if(speed.Unit is ImperialSpeedDimension imperialSpeedDimension)
                return new Distance(speed.Value * duration.ConvertValue(imperialSpeedDimension.BaseDimension), imperialSpeedDimension.Dimension);

            MeterPerSecond meterPerSecond = new MeterPerSecond(speed.Unit.ConvertValue(speed.Value, SpeedDimension.MeterPerSecond));
            return new Distance(speed.Value * duration.ConvertValue(SpeedDimension.MeterPerSecond.BaseDimension), SpeedDimension.MeterPerSecond.Dimension);
        }
            

        public static Acceleration operator /(in Speed speed, in Duration duration)
        {
            if(speed.Unit is SISpeedDimension siSpeedDimension)
                return new Acceleration(speed.Value / duration.Value, new SIAccelerationDimension(siSpeedDimension, duration.Unit));

            if (speed.Unit is ImperialSpeedDimension imperialSpeedDimension)
                return new Acceleration(speed.Value / duration.Value, new ImperialAccelerationDimension(imperialSpeedDimension, duration.Unit));

            MeterPerSecond meterPerSecond = new MeterPerSecond(speed.Unit.ConvertValue(speed.Value, SpeedDimension.MeterPerSecond));
            return new Acceleration(meterPerSecond.Value / duration.Value, new SIAccelerationDimension(SpeedDimension.MeterPerSecond, duration.Unit));
        }
            
    }
}
