using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public interface IExponentUnit<TBaseDimension, TDimension> : IUnit<TBaseDimension>
        where TBaseDimension : IUnit<TBaseDimension>
        where TDimension : IUnit<TDimension>
    {
        TDimension Dimension { get; }
        int Exponent { get; }
    }
}
