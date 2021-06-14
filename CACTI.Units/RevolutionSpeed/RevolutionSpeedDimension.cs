namespace CACTI.Units
{
    public class RevolutionSpeedDimension : ComposedUnit<RevolutionDimension, DurationDimension>, IUnit<RevolutionSpeedDimension>
    {
        public RevolutionSpeedDimension(RevolutionDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, RevolutionSpeedDimension unit)
            => base.ConvertValue(value, unit);
    }
}
