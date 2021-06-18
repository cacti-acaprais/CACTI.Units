using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Kelvin : Temperature
    {
        public Kelvin(double value) : base(value, TemperatureDimension.Kelvin)
        {
        }

        public static implicit operator Kelvin(double value)
            => new Kelvin(value);

        public static Kelvin Convert(Temperature temperature)
            => new Kelvin(temperature.Unit.ConvertValue(temperature.Value, TemperatureDimension.Kelvin));
    }
}
