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
            => GetBaseValue(value) / unit.Ratio;

        public double GetBaseValue(double value)
            => value * Ratio;
    }
}
