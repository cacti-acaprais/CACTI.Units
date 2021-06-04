using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionPerMinute : RevolutionSpeed
    {
        public RevolutionPerMinute(double value) : base(value, RevolutionSpeedUnits.RevolutionPerMinute)
        {
        }

        public static implicit operator RevolutionPerMinute(double value)
            => new RevolutionPerMinute(value);

        public static RevolutionPerMinute Convert(RevolutionSpeed speed)
            => new RevolutionPerMinute(speed.Unit.ConvertValue(speed.Value, RevolutionSpeedUnits.RevolutionPerMinute));
    }
}
