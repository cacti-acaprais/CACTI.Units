using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionPerMinuteUnit : RevolutionSpeedDimension
    {
        public static RevolutionPerMinuteUnit Unit { get; } = new RevolutionPerMinuteUnit();

        public RevolutionPerMinuteUnit() : base(RevolutionUnits.Revolution, DurationUnits.Minute)
        {
        }
    }
}
