using CACTI.Units.Durations;
using CACTI.Units.Ratios;
using CACTI.Units.RevolutionSpeeds;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Revolutions
{
    public partial class Revolution
    {
        public Revolution(double value) : this(value, RevolutionDimension.Revolution)
        {

        }
        public static Revolution Convert(Revolution revolution)
            => new Revolution(revolution.Unit.ConvertValue(revolution.Value, RevolutionDimension.Revolution));

        public static implicit operator Revolution(double value)
            => new Revolution(value);

        public static RevolutionSpeed operator /(Revolution revolution, Duration duration)
            => new RevolutionSpeed(revolution.Value / duration.Value, new RevolutionSpeedDimension(revolution.Unit, duration.Unit));
    }
}
