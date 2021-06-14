using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KelvinUnit : TemperatureDimension
    {
        public static KelvinUnit Unit { get; } = new KelvinUnit();

        public override string Symbol => "K";

        public override double Ratio => 1;

        public double Offset => 273.15;

        public override double GetBaseValue(double value)
            => (value - Offset) * Ratio;

        public override double FromBaseValue(double value)
            => (value / Ratio) + Offset;
    }
}
