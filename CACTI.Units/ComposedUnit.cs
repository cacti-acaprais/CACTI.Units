using System;

namespace CACTI.Units
{
    public class ComposedUnit<TDimension, TBaseDimension> : IComposedUnit<TDimension, TBaseDimension>
        where TDimension : IUnit<TDimension>
        where TBaseDimension : IUnit<TBaseDimension>
    {

        public ComposedUnit(TDimension dimension, TBaseDimension baseDimension)
        {
            if (dimension is null) throw new ArgumentNullException(nameof(dimension));
            if (baseDimension is null) throw new ArgumentNullException(nameof(baseDimension));

            Dimension = dimension;
            BaseDimension = baseDimension;

            Symbol = $"{(dimension is IComposedUnit ? $"({dimension.Symbol})" : dimension.Symbol)}/{baseDimension.Symbol}";
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

        public override bool Equals(object? obj)
            => obj is ComposedUnit<TDimension, TBaseDimension> other
            && Dimension.Equals(other.Dimension)
            && BaseDimension.Equals(other.BaseDimension);

        public override int GetHashCode()
            => HashCode.Combine(Dimension.GetHashCode(), BaseDimension.GetHashCode());
    }
}
