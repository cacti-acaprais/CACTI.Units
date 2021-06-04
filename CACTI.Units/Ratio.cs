using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Ratio : UnitValue<RatioDimension, Ratio>
    {
        public Ratio(double value) : this(value, RatioUnits.Ratio)
        {
            
        }

        public Ratio(double value, [NotNull] RatioDimension unit) : base(value, unit)
        {
        }

        public override Ratio Convert(RatioDimension unit)
            => new Ratio(Unit.ConvertValue(Value, unit), unit);

        public static implicit operator Ratio(double value)
            => new Ratio(value);

        public static Ratio Convert(Ratio ratio)
            => new Ratio(ratio.Unit.ConvertValue(ratio.Value, RatioUnits.Ratio));
    }
}
