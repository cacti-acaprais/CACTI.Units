using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class TemperatureUnits : IDimensionUnits<TemperatureDimension>
    {
        public static CelciusUnit Celcius => CelciusUnit.Unit;
        public static FarenheightUnit Farenheight => FarenheightUnit.Unit;
        public static KelvinUnit Kelvin => KelvinUnit.Unit;

        public TemperatureDimension[] Units = new TemperatureDimension[]
        {
            Celcius,
            Farenheight,
            Kelvin
        };

        IEnumerable<TemperatureDimension> IDimensionUnits<TemperatureDimension>.Units => Units;
    }
}
