using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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
            Value = value;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        public TDimension Unit { get; }
        public double Value { get; }

        public override int GetHashCode()
            => HashCode.Combine(Unit.GetBaseValue(Value));

        public override bool Equals(object obj)
            => obj is TValue other
            && Equals(other);

        public override string ToString()
            => ToString(null, null);

        public string ToString(string format)
            => ToString(format, null);

        public string ToString(IFormatProvider formatProvider)
            => ToString(null, formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider)
            => $"{Value.ToString(format, formatProvider)} {Unit.Symbol}";

        public bool Equals(TValue other)
            => other != null
            && (
                (Unit.Equals(other.Unit) && Value.Equals(other.Value))
                || (other.Unit.GetBaseValue(other.Value) == Unit.GetBaseValue(Value))
            ); 

        public int CompareTo(TValue other)
        {
            if (other == null)
                return 1;

            double otherBaseValue = other.Unit.GetBaseValue(other.Value);
            double baseValue = Unit.GetBaseValue(Value);

            if (baseValue > otherBaseValue)
                return 1;

            if (baseValue < otherBaseValue)
                return -1;

            return 0;
        }

        protected static double Operation(TValue value1, TValue value2, Func<double, double, double> operation)
        {
            double convertedValue2 = value2.Unit.ConvertValue(value2.Value, value1.Unit);
            return operation(value1.Value, convertedValue2);
        }

        public abstract TValue Convert(TDimension unit);
    }
}
