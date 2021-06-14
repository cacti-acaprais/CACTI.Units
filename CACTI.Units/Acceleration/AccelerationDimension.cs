namespace CACTI.Units
{
    public class AccelerationDimension : ComposedUnit<SpeedDimension, DurationDimension>, IUnit<AccelerationDimension>
    {
        public AccelerationDimension(SpeedDimension dimension, DurationDimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, AccelerationDimension unit)
            => base.ConvertValue(value, unit);
    }
}
