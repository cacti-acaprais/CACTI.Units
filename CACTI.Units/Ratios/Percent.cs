using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CACTI.Units.Ratios
{
    public readonly struct Percent : IUnitValue<RatioDimension, Ratio>, IEquatable<Ratio>, IEquatable<Percent>
    {
        private readonly double _value;

        [JsonConstructor]
        public Percent(double value)
        {
            if (double.IsNaN(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is NaN");
            if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is Infinity");
            _value = value;
        }

        public double Value => _value;
        public RatioDimension Unit => RatioDimension.Percent;

        public Ratio Convert(in RatioDimension unit)
            => new Ratio(RatioDimension.Percent.ConvertValue(Value, unit), unit);

        public double ConvertValue(in RatioDimension unit)
            => RatioDimension.Percent.ConvertValue(Value, unit);

        public static implicit operator Ratio(in Percent percent)
            => new Ratio(percent.Value, RatioDimension.Percent);

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

        public static bool TryParse(in string valueString, [NotNullWhen(true)] out Percent? value)
            => TryParse(valueString, formatProvider: null, out value);

        public static bool TryParse(in string valueString, in IFormatProvider? formatProvider, [NotNullWhen(true)] out Percent? percent)
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

        public override int GetHashCode()
            => HashCode.Combine(RatioDimension.Percent.GetBaseValue(Value));

        public override string ToString()
            => ToString(null, null);

        public string ToString(string? format)
            => ToString(format, null);

        public string ToString(IFormatProvider? formatProvider)
            => ToString(null, formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider)
            => $"{Value.ToString(format, formatProvider)} {RatioDimension.Percent.Symbol}";

        public override bool Equals(object? obj)
            => obj is Ratio ratio ? Equals(ratio)
            : obj is Percent p ? Equals(p)
            : obj is IUnitValue<RatioDimension, Ratio> unitValue && Equals(unitValue);

        public bool Equals(Ratio other)
            => other.Unit != null && Value.Equals(other.ConvertValue(RatioDimension.Percent));

        public bool Equals(Percent other)
            => Value.Equals(other.Value);

        public bool Equals(IUnitValue<RatioDimension, Ratio> other)
            => other != null && other.Unit != null && Value.Equals(other.ConvertValue(RatioDimension.Percent));

        public int CompareTo(object? obj)
        {
            switch (obj)
            {
                case Ratio ratio:
                    return CompareTo(ratio);
                case Percent p:
                    return Value.CompareTo(p.Value);
                case IUnitValue<RatioDimension, Ratio> ratioValue:
                    return Value.CompareTo(ratioValue.ConvertValue(RatioDimension.Percent));
                default:
                    return obj == null
                        ? 1
                        : throw new ArgumentException("Invalid comparison object type");
            }
        }

        public int CompareTo(Ratio other)
            => other.Unit != null
            ? Value.CompareTo(other.ConvertValue(RatioDimension.Percent))
            : 1;

        public int CompareTo(IUnitValue<RatioDimension, Ratio> other)
            => other != null
            ? Value.CompareTo(other.ConvertValue(RatioDimension.Percent))
            : 1;
    }
}
