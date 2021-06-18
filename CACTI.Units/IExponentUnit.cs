using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public interface IExponentUnit<TDimension> : IUnit<IExponentUnit<TDimension>>
        where TDimension : IUnit<TDimension>
    {
        TDimension Dimension { get; }
        int Exponent { get; }
    }
}
