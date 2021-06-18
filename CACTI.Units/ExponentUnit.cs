using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class ExponentUnit<TDimension> : IExponentUnit<TDimension>
        where TDimension : Unit<TDimension>, IUnit<TDimension>
    {
        public ExponentUnit(TDimension dimension, int exponent)
        {
            if (exponent < 2) throw new ArgumentOutOfRangeException(nameof(exponent), $"Exponent can't be lower than 2"); 

            Dimension = dimension ?? throw new ArgumentNullException(nameof(dimension));
            Exponent = exponent;
            Symbol = $"{dimension.Symbol}{exponent}";
            Ratio = Math.Pow(dimension.Ratio, exponent); 
        }

        public double Ratio { get; }

        public TDimension Dimension { get; }
        public int Exponent { get; }

        public string Symbol { get; }

        public double ConvertValue(double value, IExponentUnit<TDimension> unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));

            if (unit.Equals(this))
                return value;

            double baseValue = GetBaseValue(value);

            return unit.FromBaseValue(baseValue);
        }

        public double FromBaseValue(double value)
            => value / Ratio;

        public double GetBaseValue(double value)
            => value * Ratio;
    }
}
