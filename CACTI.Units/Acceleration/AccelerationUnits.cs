using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class AccelerationUnits : IDimensionUnits<AccelerationDimension>
    {
        public AccelerationUnits(SpeedUnits speedUnits, DurationUnits durationUnits)
        {
            Units = ComputeUnits(speedUnits.Units, durationUnits.Units)
                .ToArray();
        }

        public static MeterPerSecondPerSecondUnit MeterPerSecondPerSecond => MeterPerSecondPerSecondUnit.Unit;

        public AccelerationDimension[] Units { get; }

        IEnumerable<AccelerationDimension> IDimensionUnits<AccelerationDimension>.Units => Units;

        private IEnumerable<AccelerationDimension> ComputeUnits(IEnumerable<SpeedDimension> speedDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (SpeedDimension speedDimension in speedDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new AccelerationDimension(speedDimension, durationDimension);
        }
    }
}
