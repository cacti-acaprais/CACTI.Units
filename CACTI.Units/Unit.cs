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
        public abstract string Symbol { get; }
        public abstract double Ratio { get; }

        public double ConvertValue(double value, TDimension unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));

            if (unit.Equals(this))
                return value;

            double baseValue = GetBaseValue(value);

            return unit.FromBaseValue(baseValue);
        }

        public virtual double FromBaseValue(double value)
            => value / Ratio;
        
        public virtual double GetBaseValue(double value)
            => value * Ratio;
    }
}
