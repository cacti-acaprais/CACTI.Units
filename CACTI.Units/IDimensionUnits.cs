using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public interface IDimensionUnits<TDimension>
        where TDimension : IUnit<TDimension>
    {
        IEnumerable<TDimension> Units { get; }
    }
}
