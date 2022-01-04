using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Ratios
{
    public class Ratio : UnitValue<RatioDimension, Ratio>
    {
        public Ratio(double value) : this(value, RatioDimension.RatioUnit)
        {
            
        }

        public Ratio(double value, RatioDimension unit) : base(value, unit)
        {
        }

        public override Ratio Convert(RatioDimension unit)
            => new Ratio(Unit.ConvertValue(Value, unit), unit);

        public static implicit operator Ratio(double value)
            => new Ratio(value);

        public static Ratio Convert(Ratio ratio)
            => new Ratio(ratio.Unit.ConvertValue(ratio.Value, RatioDimension.RatioUnit));

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Ratio? ratio)
            => TryParse(valueString, null, out ratio);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Ratio? ratio)
        {
            if (valueString is null) throw new ArgumentNullException(nameof(valueString));

            ratio = default;

            if (!UnitValueParser.TryParse<RatioDimension, Ratio>(valueString, RatioDimension.Units, formatProvider, out double value, out RatioDimension? unit))
                return false;

            ratio = new Ratio(value, unit);
            return true;
        }
    }
}
