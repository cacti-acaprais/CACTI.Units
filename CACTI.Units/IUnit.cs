using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IUnit
    {
        string Symbol { get; }
    }

    public interface IUnit<TDimension> : IUnit
        where TDimension : IUnit<TDimension>
    {
        double ConvertValue(double value, TDimension unit);
        double GetBaseValue(double value);
        double FromBaseValue(double value);
    }
}
