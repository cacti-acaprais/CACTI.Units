using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace CACTI.Units
{
    public abstract class UnitValue<TDimension, TValue> : IUnitValue<TDimension, TValue>
        where TDimension : IUnit<TDimension>
        where TValue : IUnitValue<TDimension, TValue>
    {
        protected static Func<double, double, double> Addition { get; } = (val1, val2) => val1 + val2;
        protected static Func<double, double, double> Substraction { get; } = (val1, val2) => val1 - val2;
        protected static Func<double, double, double> Division { get; } = (val1, val2) => val1 / val2;


        public UnitValue(double value, TDimension unit)
        {
            if (unit is null) throw new ArgumentNullException(nameof(unit));
            if (double.IsNaN(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is NaN");
            if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} is Infinity");

            Value = value;
            Unit = unit;
        }

        public TDimension Unit { get; }
        public double Value { get; }

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

        public override bool Equals(object? obj)
            => obj is TValue other
            && Equals(other);

        public bool Equals(TValue? other)
            => other is not null
            && (
                (Unit.Equals(other.Unit) && Value.Equals(other.Value))
                || (other.Unit.GetBaseValue(other.Value) == Unit.GetBaseValue(Value))
            );

        public bool Equals(TValue other, double precision)
        {
            if (other is null)
                return false;

            if (double.IsNaN(precision))
                return false;

            double otherValue = Unit.Equals(other.Unit)
                ? other.Value
                : other.Convert(Unit).Value;

            return Value - otherValue < precision;
        }

        public int CompareTo(object? obj)
        {
            if (obj is TValue other)
                return CompareTo(other);

            return 1;
        }

        public int CompareTo(TValue? other)
        {
            if (other is null)
                return 1;

            double otherBaseValue = other.Unit.GetBaseValue(other.Value);
            double baseValue = Unit.GetBaseValue(Value);

            return baseValue.CompareTo(otherBaseValue);
        }

        protected static double Operation(TValue value1, TValue value2, Func<double, double, double> operation)
        {
            double convertedValue2 = value2.Unit.ConvertValue(value2.Value, value1.Unit);
            return operation(value1.Value, convertedValue2);
        }

        public static bool operator ==(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => EqualityComparer<UnitValue<TDimension, TValue>>.Default.Equals(left, right);

        public static bool operator !=(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => !EqualityComparer<UnitValue<TDimension, TValue>>.Default.Equals(left, right);

        public static bool operator >(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => Comparer<UnitValue<TDimension, TValue>>.Default.Compare(left, right) > 0;

        public static bool operator <(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => Comparer<UnitValue<TDimension, TValue>>.Default.Compare(left, right) < 0;

        public static bool operator <=(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => Comparer<UnitValue<TDimension, TValue>>.Default.Compare(left, right) <= 0;

        public static bool operator >=(UnitValue<TDimension, TValue> left, UnitValue<TDimension, TValue> right)
            => Comparer<UnitValue<TDimension, TValue>>.Default.Compare(left, right) >= 0;

        public abstract TValue Convert(TDimension unit);
    }
}
