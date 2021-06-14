using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class ComposedUnit<TDimension, TBaseDimension> : IComposedUnit<TDimension, TBaseDimension>
        where TDimension : IUnit<TDimension>
        where TBaseDimension : IUnit<TBaseDimension>
    {

        public ComposedUnit(TDimension dimension, TBaseDimension baseDimension)
        {
            Dimension = dimension;
            BaseDimension = baseDimension;

            //TODO : if dimension is composed, display dimension as (dimension)/baseDimension
            Symbol = $"{dimension.Symbol}/{baseDimension.Symbol}";
        }

        public string Symbol { get; }

        public TDimension Dimension { get; }

        public TBaseDimension BaseDimension { get; }

        public double ConvertValue(double value, IComposedUnit<TDimension, TBaseDimension> unit)
            => Dimension.ConvertValue(value, unit.Dimension) / BaseDimension.ConvertValue(1, unit.BaseDimension);

        public double FromBaseValue(double value)
            => Dimension.FromBaseValue(value) / BaseDimension.FromBaseValue(1);

        public double GetBaseValue(double value)
            => Dimension.GetBaseValue(value) / BaseDimension.GetBaseValue(1);
    }
}
