using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Mass : UnitValue<MassDimension, Mass>
    {
        public Mass(double value, MassDimension unit) : base(value, unit)
        {
        }

        public override Mass Convert(MassDimension unit)
            => new Mass(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Mass mass1, Mass mass2)
            => new Ratio(Operation(mass1, mass2, Division));

        public static Mass operator *(Mass mass, double value)
            => new Mass(mass.Value * value, mass.Unit);

        public static Mass operator /(Mass mass, double value)
            => new Mass(mass.Value / value, mass.Unit);

        public static Mass operator +(Mass mass1, Mass mass2)
            => new Mass(Operation(mass1, mass2, Addition), mass1.Unit);

        public static Mass operator -(Mass mass1, Mass mass2)
            => new Mass(Operation(mass1, mass2, Substraction), mass1.Unit);
    }
}
