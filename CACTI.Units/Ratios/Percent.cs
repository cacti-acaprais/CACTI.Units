using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Ratios
{
    public class Percent : Ratio
    {
        public Percent(double value) : base(value, RatioDimension.Percent)
        {
        }

        public static implicit operator Percent(double value)
            => new Percent(value);

        public static new Percent Convert(Ratio ratio)
            => new Percent(ratio.Unit.ConvertValue(ratio.Value, RatioDimension.Percent));
    }
}
