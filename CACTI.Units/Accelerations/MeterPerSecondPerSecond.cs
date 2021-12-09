namespace CACTI.Units.Accelerations
{
    public class MeterPerSecondPerSecond : Acceleration
    {
        public MeterPerSecondPerSecond(double value) : base(value, AccelerationDimension.MeterPerSecondPerSecond)
        {
        }

        public static implicit operator MeterPerSecondPerSecond(double value)
            => new MeterPerSecondPerSecond(value);

        public static MeterPerSecondPerSecond Convert(Acceleration acceleration)
            => new MeterPerSecondPerSecond(acceleration.Unit.ConvertValue(acceleration.Value, AccelerationDimension.MeterPerSecondPerSecond));
    }
}
