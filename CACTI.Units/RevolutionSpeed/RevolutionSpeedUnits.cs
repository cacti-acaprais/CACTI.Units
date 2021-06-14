using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionSpeedUnits : IDimensionUnits<RevolutionSpeedDimension>
    {
        public RevolutionSpeedUnits()
        {

        }

        public static RevolutionPerMinuteUnit RevolutionPerMinute { get; } = RevolutionPerMinuteUnit.Unit;
        public static RevolutionPerSecondUnit RevolutionPerSecond { get; } = RevolutionPerSecondUnit.Unit;

        public RevolutionSpeedDimension[] Units { get; } = new RevolutionSpeedDimension[]
        {
            RevolutionPerSecond,
            RevolutionPerMinute
        };

        IEnumerable<RevolutionSpeedDimension> IDimensionUnits<RevolutionSpeedDimension>.Units => Units;
    }
}
