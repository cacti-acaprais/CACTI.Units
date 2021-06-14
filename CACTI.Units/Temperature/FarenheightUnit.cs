using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class FarenheightUnit : TemperatureDimension
    {
        public static FarenheightUnit Unit { get; } = new FarenheightUnit();

        public override string Symbol => "°F";

        public override double Ratio => 5d/9d;

        public double Offset => 32;

        public override double GetBaseValue(double value)
            => (value - Offset) * Ratio;

        public override double FromBaseValue(double value)
            => (value / Ratio) + Offset;
    }
}
