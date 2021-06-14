using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Farenheight : Temperature
    {
        public Farenheight(double value) : base(value, TemperatureUnits.Farenheight)
        {
        }

        public static implicit operator Farenheight(double value)
            => new Farenheight(value);

        public static Farenheight Convert(Temperature temperature)
            => new Farenheight(temperature.Unit.ConvertValue(temperature.Value, TemperatureUnits.Farenheight));
    }
}
