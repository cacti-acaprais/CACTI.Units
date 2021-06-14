using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Temperature : UnitValue<TemperatureDimension, Temperature>
    {
        public Temperature(double value, TemperatureDimension unit) : base(value, unit)
        {
        }

        public override Temperature Convert(TemperatureDimension unit)
            => new Temperature(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Temperature temperature1, Temperature temperature2)
            => new Ratio(Operation(temperature1, temperature2, Division));

        public static Temperature operator *(Temperature temperature, double value)
            => new Temperature(temperature.Value * value, temperature.Unit);

        public static Temperature operator /(Temperature temperature, double value)
            => new Temperature(temperature.Value / value, temperature.Unit);

        public static Temperature operator +(Temperature temperature1, Temperature temperature2)
            => new Temperature(Operation(temperature1, temperature2, Addition), temperature1.Unit);

        public static Temperature operator -(Temperature temperature1, Temperature temperature2)
            => new Temperature(Operation(temperature1, temperature2, Substraction), temperature1.Unit);
    }
}
