using CACTI.Units.Forces;
using CACTI.Units.Gravities;
using CACTI.Units.Masses;
using CACTI.Units.Ratios;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Accelerations
{
    public partial class Acceleration
    {
        
        public static MeterPerSecondPerSecond Convert(Gravity gravity)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = gravity.Value / ForceDimension.KilogramForce.Ratio;
            return meterPerSecondPerSecond;
        }

        public static implicit operator Acceleration(Gravity gravity)
            => Convert(gravity);

        public static Newton operator *(Mass mass, Acceleration acceleration)
            => acceleration * mass;

        public static Newton operator *(Acceleration acceleration, Mass mass)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Kilogram kilogram = Kilogram.Convert(mass);

            return meterPerSecondPerSecond.Value * kilogram.Value;
        }
    }
}
