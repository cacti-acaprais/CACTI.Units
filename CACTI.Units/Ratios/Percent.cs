using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CACTI.Units.Ratios
{
    public class Percent : Ratio
    {
        private readonly double _value;

        [JsonConstructor]
        public Percent(double value) : base(value, RatioDimension.Percent) 
        { }

        public static bool operator ==(in Percent left, in Ratio right)
            => left.Equals(right);

        public static bool operator !=(in Percent left, in Ratio right)
            => !left.Equals(right);

        public static bool operator >(in Percent left, in Ratio right)
            => left.CompareTo(right) > 0;

        public static bool operator <(in Percent left, in Ratio right)
            => left.CompareTo(right) < 0;

        public static bool operator <=(in Percent left, in Ratio right)
            => left.CompareTo(right) <= 0;

        public static bool operator >=(in Percent left, in Ratio right)
            => left.CompareTo(right) >= 0;

        public static Percent operator +(in Percent value1, in Ratio value2)
            => new Percent(value1.Value + value2.ConvertValue(RatioDimension.Percent));

        public static Percent operator -(in Percent value1, in Ratio value2)
            => new Percent(value1.Value - value2.ConvertValue(RatioDimension.Percent));

        public static explicit operator Percent(in double value)
            => new Percent(value);

        public static Percent Convert(in Ratio value)
            => new Percent(value.Unit.ConvertValue(value.Value, RatioDimension.Percent));

        public static Percent? Parse(in string valueString)
            => Parse(valueString, formatProvider: null);

        public static Percent? Parse(in string valueString, in IFormatProvider? formatProvider)
            => TryParse(valueString, formatProvider, out Percent? value)
            ? value
            : (Percent?)null;

        public static bool TryParse(in string valueString, out Percent? value)
            => TryParse(valueString, formatProvider: null, out value);

        public static bool TryParse(in string valueString, in IFormatProvider? formatProvider, out Percent? percent)
        {
            if (UnitValueParser.TryParse(valueString, RatioDimension.Units, formatProvider: null, out double value, out RatioDimension unit))
            {
                percent = unit == RatioDimension.Percent
                    ? new Percent(value)
                    : new Percent(unit.ConvertValue(value, RatioDimension.Percent));

                return true;
            }

            percent = default;
            return false;
        }

        public override string ToString()
            => ToString(null, null);

        public override bool Equals(object? obj)
            => obj is IUnitValue<RatioDimension, Ratio> unitValue && Equals(unitValue);
    }
}
