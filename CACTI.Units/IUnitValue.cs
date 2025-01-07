using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IUnitValue<TDimension, TValue> :
        IEquatable<IUnitValue<TDimension, TValue>>,
        IComparable<IUnitValue<TDimension, TValue>>,
        IComparable,
        IFormattable
        where TDimension : IUnit<TDimension>
        where TValue : IUnitValue<TDimension, TValue>
    {
        TValue Convert(in TDimension unit);
        double ConvertValue(in TDimension unit);

        double Value { get; }
        TDimension Unit { get; }
    }
}
