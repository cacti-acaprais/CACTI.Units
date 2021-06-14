namespace CACTI.Units
{
    public class MeterPerHourUnit : SpeedDimension
    {
        public static MeterPerHourUnit Unit { get; } = new MeterPerHourUnit();

        public MeterPerHourUnit() : base(LengthUnits.Meter, DurationUnits.Hour)
        {
        }
    }
}
