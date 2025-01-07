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
        double ConvertValue(in double value, in TDimension unit);
        double GetBaseValue(in double value);
        double FromBaseValue(in double value);
    }
}
