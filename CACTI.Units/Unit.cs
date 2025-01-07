using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace CACTI.Units
{
    public abstract class Unit<TDimension> : IUnit<TDimension>
        where TDimension : Unit<TDimension>
    {
        public Unit(string symbol, double ratio)
            : this(symbol: symbol, ratio: ratio, offset: 0)
        {

        }

        public Unit(string symbol, double ratio, double offset)
        {
            if (ratio == 0) throw new ArgumentOutOfRangeException(nameof(ratio));

            Ratio = ratio;
            Offset = offset;
            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
        }

        public string Symbol { get; }
        public double Ratio { get; }
        public double Offset { get; }

        public double ConvertValue(in double value, in TDimension unit)
        {
            if (unit is null) throw new ArgumentNullException(nameof(unit));

            if (unit.Equals(this))
                return value;

            double baseValue = GetBaseValue(value);

            return unit.FromBaseValue(baseValue);
        }

        public bool TryGetCompatibleUnit<TOtherDimension>(in IEnumerable<TOtherDimension> otherUnits, out TOtherDimension? otherUnit)
            where TOtherDimension : Unit<TOtherDimension>
        {
            if (otherUnits is null) throw new ArgumentNullException(nameof(otherUnits));

            otherUnit = otherUnits.FirstOrDefault(x => x.Ratio == Ratio);
            return !(otherUnit is null);
        }

        public override bool Equals(object? obj)
            => obj is TDimension other
            && other.Ratio == Ratio
            && other.Symbol == Symbol
            && other.Offset == Offset;

        public override int GetHashCode()
            => HashCode.Combine(Ratio, Symbol, Offset);

        public double FromBaseValue(in double value)
            => (value / Ratio) + Offset;

        public double GetBaseValue(in double value)
            => (value - Offset) * Ratio;

        protected const double Mega = 1e6;
        protected const double Kilo = 1e3;
        protected const double Hecto = 1e2;
        protected const double Deca = 1e1;
        protected const double Deci = 1e-1;
        protected const double Centi = 1e-2;
        protected const double Milli = 1e-3;
        protected const double Micro = 1e-6;
        protected const double Nano = 1e-9;

        // Disk size constants
        protected const double K = 1024;
        protected const double M = K * 1024;
        protected const double G = M * 1024;
        protected const double T = G * 1024;
    }
}
