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
    public partial class Gravity : IUnitValue<GravityDimension, Gravity>
    {
        public Gravity(double value) : this(value, GravityDimension.Gravity)
        {

        }

        public static implicit operator Gravity(in double value)
            => new Gravity(value);

        public MeterPerSecondPerSecond ToAcceleration()
            => Value * ForceDimension.KilogramForce.Ratio;

        public static implicit operator Acceleration(in Gravity gravity)
            => gravity.ToAcceleration();
    }
}
