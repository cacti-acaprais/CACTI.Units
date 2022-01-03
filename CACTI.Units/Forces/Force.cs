using CACTI.Units.Accelerations;
using CACTI.Units.Masses;
using CACTI.Units.Ratios;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.Forces
{
    public partial class Force
    {
        public static MeterPerSecondPerSecond operator /(Force force, Mass mass)
        {
            Newton newton = Newton.Convert(force);
            Kilogram kilogram = Kilogram.Convert(mass);

            return newton.Value / kilogram.Value;
        }
    }
}
