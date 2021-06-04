using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionPerSecondUnit : RevolutionSpeedDimension
    {
        public static RevolutionPerSecondUnit Unit { get; } = new RevolutionPerSecondUnit();

        public RevolutionPerSecondUnit() : base(RevolutionUnits.Revolution, DurationUnits.Second)
        {
        }
    }
}
