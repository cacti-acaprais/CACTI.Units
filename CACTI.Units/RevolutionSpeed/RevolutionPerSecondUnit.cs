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
