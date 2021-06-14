namespace CACTI.Units
{
    public class MeterPerSecondUnit : SpeedDimension
    {
        public static MeterPerSecondUnit Unit { get; } = new MeterPerSecondUnit();

        public MeterPerSecondUnit() : base(LengthUnits.Meter, DurationUnits.Second)
        {
        }
    }
}
