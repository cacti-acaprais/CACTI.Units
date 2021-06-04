using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IComposedUnit<TDimension, TBaseDimension> : IUnit<IComposedUnit<TDimension, TBaseDimension>>
        where TDimension : IUnit<TDimension>
        where TBaseDimension : IUnit<TBaseDimension>
        
    {
        TDimension Dimension { get; }
        TBaseDimension BaseDimension { get; }
    }
}
