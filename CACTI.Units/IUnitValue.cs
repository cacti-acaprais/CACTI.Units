using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IUnitValue<TDimension, TValue> :
        IEquatable<TValue>,
        IComparable<TValue>
        where TDimension : IUnit<TDimension>
        where TValue : IUnitValue<TDimension, TValue>
    {
        public TDimension Unit { get; }
        public double Value { get; }
        public TValue Convert(TDimension unit);
    }
}
