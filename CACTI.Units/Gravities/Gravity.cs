using CACTI.Units.Accelerations;
using CACTI.Units.Forces;
using CACTI.Units.Ratios;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Gravities
{
    public partial class Gravity
    {
        public Gravity(double value) : this(value, GravityDimension.Gravity)
        {

        }

        public static implicit operator Gravity(double value)
            => new Gravity(value);

        public static implicit operator Gravity(Acceleration acceleration)
            => Convert(acceleration);

        public static Gravity Convert(Acceleration acceleration)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            double gravityValue = meterPerSecondPerSecond.Value / ForceDimension.KilogramForce.Ratio;
            return gravityValue;
        }
    }
}
