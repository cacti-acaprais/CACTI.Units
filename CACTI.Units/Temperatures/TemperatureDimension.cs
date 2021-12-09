using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Temperatures
{
    public class TemperatureDimension : Unit<TemperatureDimension>
    {
        public TemperatureDimension(string symbol, double ratio, double offset) : base(symbol, ratio, offset)
        {
        }

        public static TemperatureDimension Celcius { get; } = new TemperatureDimension("°C", 1, 0);
        public static TemperatureDimension Farenheight => new TemperatureDimension("°F", 5d / 9d, 32);
        public static TemperatureDimension Kelvin => new TemperatureDimension("K", 1, 273.15);

        public static TemperatureDimension[] Units = new TemperatureDimension[]
        {
            Celcius,
            Farenheight,
            Kelvin
        };
    }
}
