namespace CACTI.Units
{
    public class Speed : UnitValue<SpeedDimension, Speed>
    {
        public Speed(double value, SpeedDimension unit) : base(value, unit)
        {
        }

        public override Speed Convert(SpeedDimension unit)
            => new Speed(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Speed speed1, Speed speed2)
            => new Ratio(Operation(speed1, speed2, Division));

        public static Speed operator +(Speed speed1, Speed speed2)
            => new Speed(Operation(speed1, speed2, Addition), speed1.Unit);

        public static Speed operator -(Speed speed1, Speed speed2)
            => new Speed(Operation(speed1, speed2, Substraction), speed1.Unit);

        public static Speed operator *(Speed speed, double value)
            => new Speed(speed.Value * value, speed.Unit);

        public static Speed operator /(Speed speed, double value)
            => new Speed(speed.Value / value, speed.Unit);

        public static Length operator *(Speed speed, Duration duration)
        {
            Duration convertedDuration = duration.Convert(speed.Unit.BaseDimension);
            return new Length(speed.Value * convertedDuration.Value, speed.Unit.Dimension);
        }

        public static Acceleration operator /(Speed speed, Duration duration)
            => new Acceleration(speed.Value / duration.Value, new AccelerationDimension(speed.Unit, duration.Unit));
    }
}
