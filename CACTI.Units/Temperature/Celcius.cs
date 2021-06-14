using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Celcius : Temperature
    {
        public Celcius(double value) : base(value, TemperatureUnits.Celcius)
        {
        }

        public static implicit operator Celcius(double value)
            => new Celcius(value);

        public static Celcius Convert(Temperature temperature)
            => new Celcius(temperature.Unit.ConvertValue(temperature.Value, TemperatureUnits.Celcius));
    }
}
