using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IUnit<TDimension>
        where TDimension : IUnit<TDimension>
    {
        public string Symbol { get; }
        public double ConvertValue(double value, TDimension unit);
        public double GetBaseValue(double value);
    }
}
