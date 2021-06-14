namespace CACTI.Units
{
    public class Acceleration : UnitValue<AccelerationDimension, Acceleration>
    {
        public Acceleration(double value, AccelerationDimension unit) : base(value, unit)
        {
        }

        public override Acceleration Convert(AccelerationDimension unit)
            => new Acceleration(Unit.ConvertValue(Value, unit), unit);

        public static MeterPerSecondPerSecond Convert(Gravity gravity)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = gravity.Value / ForceUnits.KilogramForce.Ratio;
            return meterPerSecondPerSecond;
        }

        public static implicit operator Acceleration(Gravity gravity)
            => Convert(gravity);

        public static Ratio operator /(Acceleration acceleration1, Acceleration acceleration2)
            => new Ratio(Operation(acceleration1, acceleration2, Division));

        public static Acceleration operator *(Acceleration acceleration, double value)
            => new Acceleration(acceleration.Value * value, acceleration.Unit);

        public static Acceleration operator /(Acceleration acceleration, double value)
            => new Acceleration(acceleration.Value / value, acceleration.Unit);

        public static Acceleration operator +(Acceleration acceleration1, Acceleration acceleration2)
            => new Acceleration(Operation(acceleration1, acceleration2, Addition), acceleration1.Unit);

        public static Acceleration operator -(Acceleration acceleration1, Acceleration acceleration2)
            => new Acceleration(Operation(acceleration1, acceleration2, Substraction), acceleration1.Unit);

        public static Newton operator *(Mass mass, Acceleration acceleration)
            => acceleration * mass;

        public static Newton operator *(Acceleration acceleration, Mass mass)
        {
            MeterPerSecondPerSecond meterPerSecondPerSecond = MeterPerSecondPerSecond.Convert(acceleration);
            Kilogram kilogram = Kilogram.Convert(mass);

            return meterPerSecondPerSecond.Value * kilogram.Value;
        }
    }
}
