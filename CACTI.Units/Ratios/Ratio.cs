using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CACTI.Units.Ratios
{
    public class Ratio : IUnitValue<RatioDimension, Ratio>
    {
        private readonly double _value;
        private readonly RatioDimension _unit;

        public Ratio(double value) : this(value, RatioDimension.RatioUnit)
        { }

        [JsonConstructor]
        public Ratio(double value, RatioDimension unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            if (double.IsNaN(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is NaN");
            if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is Infinity");

            _value = value;
            _unit = unit;
        }

        public RatioDimension Unit => _unit;
        public double Value => _value;

        public static implicit operator Ratio(in double value)
            => new Ratio(value);

        public Ratio Convert(in RatioDimension unit)
            => new Ratio(Unit.ConvertValue(Value, unit), unit);

        public double ConvertValue(in RatioDimension unit)
            => Unit.ConvertValue(Value, unit);

        public static bool operator ==(in Ratio left, in Ratio right)
            => left.Equals(right);

        public static bool operator !=(in Ratio left, in Ratio right)
            => !left.Equals(right);

        public static bool operator >(in Ratio left, in Ratio right)
            => left.CompareTo(right) > 0;

        public static bool operator <(in Ratio left, in Ratio right)
            => left.CompareTo(right) < 0;

        public static bool operator <=(in Ratio left, in Ratio right)
            => left.CompareTo(right) <= 0;

        public static bool operator >=(in Ratio left, in Ratio right)
            => left.CompareTo(right) >= 0;

        public static Ratio operator +(in Ratio value1, in Ratio value2)
            => new Ratio(value1.Value + value2.ConvertValue(RatioDimension.RatioUnit));

        public static Ratio operator -(in Ratio value1, in Ratio value2)
            => new Ratio(value1.Value - value2.ConvertValue(RatioDimension.RatioUnit));

        public override int GetHashCode()
            => HashCode.Combine(Unit.GetBaseValue(Value));

        public override string ToString()
            => ToString(null, null);

        public string ToString(string? format)
            => ToString(format, null);

        public string ToString(IFormatProvider? formatProvider)
            => ToString(null, formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider)
            => $"{Value.ToString(format, formatProvider)}{(string.IsNullOrEmpty(Unit.Symbol) ? string.Empty : $" {Unit.Symbol}")}";

        public static Ratio? Parse(in string valueString)
            => Parse(valueString, formatProvider: null);

        public static Ratio? Parse(in string valueString, in IFormatProvider? formatProvider)
            => TryParse(valueString, formatProvider, out Ratio? value)
            ? value
            : (Ratio?)null;

        public static bool TryParse(in string valueString, [NotNullWhen(true)] out Ratio? value)
            => TryParse(valueString, formatProvider: null, out value);

        public static bool TryParse(in string valueString, in IFormatProvider? formatProvider, [NotNullWhen(true)] out Ratio? ratio)
        {
            if (UnitValueParser.TryParse(valueString, RatioDimension.Units, formatProvider, out double value, out RatioDimension unit))
            {
                ratio = unit == RatioDimension.Percent
                    ? new Percent(value)
                    : new Ratio(value);

                return true;
            }

            ratio = default;
            return false;
        }

        public override bool Equals(object? obj)
            => obj is IUnitValue<RatioDimension, Ratio> other && Equals(other);

        public int CompareTo(object? obj)
        {
            switch (obj)
            {
                case IUnitValue<RatioDimension, Ratio> ratioValue:
                    return CompareTo(ratioValue);
                default:
                    throw new ArgumentException("Invalid comparison object type");
            }
        }

        public bool Equals(IUnitValue<RatioDimension, Ratio>? other)
            => (other?.Unit != null && Unit != null && Value.Equals(other.ConvertValue(Unit)))
            || (other?.Unit == null && Unit == null);

        public int CompareTo(IUnitValue<RatioDimension, Ratio> other)
            => other != null
            ? Value.CompareTo(other.ConvertValue(Unit))
            : 1;
    }
}
