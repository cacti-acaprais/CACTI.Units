using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Masses;
using CACTI.Units.Forces;
using CACTI.Units.Gravities;

namespace CACTI.Units.Accelerations
{
    public partial class Acceleration
    {
        public static Newton operator *(in Acceleration acceleration, in Mass mass)
            => acceleration.ConvertValue(AccelerationDimension.MeterPerSecondPerSecond) * mass.ConvertValue(MassDimension.Kilogram);

        public Gravity ToGravity()
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(this);
            return meterPerSecondPerSecond.Value / ForceDimension.KilogramForce.Ratio;
        }

        public static implicit operator Gravity(Acceleration acceleration) 
            => acceleration.ToGravity();
    }
}
