using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public abstract class Unit<TDimension> : IUnit<TDimension>
        where TDimension : Unit<TDimension>, IUnit<TDimension>
    {
        public Unit(string symbol, double ratio)
            : this(symbol, ratio, 0)
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

        public double ConvertValue(double value, TDimension unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));

            if (unit.Equals(this))
                return value;

            double baseValue = GetBaseValue(value);

            return unit.FromBaseValue(baseValue);
        }

        public virtual double FromBaseValue(double value)
            => (value / Ratio) + Offset;

        public virtual double GetBaseValue(double value)
            => (value - Offset) * Ratio;

        protected const double Mega =  1e6;
        protected const double Kilo = 1e3;
        protected const double Deca = 1e1;
        protected const double Deci = 1e-1;
        protected const double Centi = 1e-2;
        protected const double Milli = 1e-3;
        protected const double Micro = 1e-6;
        protected const double Nano =  1e-9;
    }
}
