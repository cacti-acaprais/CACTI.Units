using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class SpeedUnits : IDimensionUnits<SpeedDimension>
    {
        public SpeedUnits(LengthUnits lengthUnits, DurationUnits durationUnits)
        {
            Units = ComputeUnits(lengthUnits.Units, durationUnits.Units)
                .ToArray();
        }

        public static MeterPerSecondUnit MeterPerSecond { get; } = MeterPerSecondUnit.Unit;
        public static MeterPerHourUnit MeterPerHour { get; } = MeterPerHourUnit.Unit;
        public static KilometerPerHourUnit KilometerPerHour { get; } = KilometerPerHourUnit.Unit;

        public SpeedDimension[] Units { get; }

        IEnumerable<SpeedDimension> IDimensionUnits<SpeedDimension>.Units => Units;

        private IEnumerable<SpeedDimension> ComputeUnits(IEnumerable<LengthDimension> lengthDimensions, IEnumerable<DurationDimension> durationDimensions)
        {
            foreach (LengthDimension lengthDimension in lengthDimensions)
                foreach (DurationDimension durationDimension in durationDimensions)
                    yield return new SpeedDimension(lengthDimension, durationDimension);
        }
    }
}
