using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class CelciusUnit : TemperatureDimension
    {
        public static CelciusUnit Unit { get; } = new CelciusUnit();

        public override string Symbol => "°C";

        public override double Ratio => 1;
    }
}
