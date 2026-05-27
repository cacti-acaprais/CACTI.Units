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
    public readonly partial struct Revolution
    {
        public static Revolution Convert(in Revolution revolution)
            => revolution.Convert(RevolutionDimension.Revolution);

        public static implicit operator Revolution(double value)
            => new Revolution(value, RevolutionDimension.Revolution);

        public static RevolutionSpeed operator /(in Revolution revolution, in Duration duration)
            => new RevolutionSpeed(revolution.Value / duration.Value, new RevolutionSpeedDimension(revolution.Unit, duration.Unit));
    }
}
