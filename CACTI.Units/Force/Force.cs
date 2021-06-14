namespace CACTI.Units
{
    public class Force : UnitValue<ForceDimension, Force>
    {
        public Force(double value, ForceDimension unit) : base(value, unit)
        {
        }

        public override Force Convert(ForceDimension unit)
            => new Force(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Force force1, Force force2)
            => new Ratio(Operation(force1, force2, Division));

        public static Force operator *(Force force, double value)
            => new Force(force.Value * value, force.Unit);

        public static Force operator /(Force force, double value)
            => new Force(force.Value / value, force.Unit);

        public static Force operator +(Force force1, Force force2)
            => new Force(Operation(force1, force2, Addition), force1.Unit);

        public static Force operator -(Force force1, Force force2)
            => new Force(Operation(force1, force2, Substraction), force1.Unit);

        public static MeterPerSecondPerSecond operator /(Force force, Mass mass)
        {
            Newton newton = Newton.Convert(force);
            Kilogram kilogram = Kilogram.Convert(mass);

            return newton.Value / kilogram.Value;
        }
    }
}
