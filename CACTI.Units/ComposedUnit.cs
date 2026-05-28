using System;
#nullable enable

namespace CACTI.Units
{
    public class ComposedUnit<TDimension, TBaseDimension> : IComposedUnit<TDimension, TBaseDimension>
        where TDimension : IUnit<TDimension>
        where TBaseDimension : IUnit<TBaseDimension>
    {
        private readonly double _baseDimensionBaseValue;
        private readonly double _baseDimensionFromBaseValue;

        public ComposedUnit(TDimension dimension, TBaseDimension baseDimension)
        {
            if (dimension == null) throw new ArgumentNullException(nameof(dimension));
            if (baseDimension == null) throw new ArgumentNullException(nameof(baseDimension));

            Dimension = dimension;
            BaseDimension = baseDimension;
            _baseDimensionBaseValue = baseDimension.GetBaseValue(1);
            _baseDimensionFromBaseValue = baseDimension.FromBaseValue(1);

            Symbol = $"{(dimension is IComposedUnit ? $"({dimension.Symbol})" : dimension.Symbol)}/{baseDimension.Symbol}";
        }

        public string Symbol { get; }

        public TDimension Dimension { get; }

        public TBaseDimension BaseDimension { get; }

        public double ConvertValue(in double value, in IComposedUnit<TDimension, TBaseDimension> unit)
            => Dimension.ConvertValue(value, unit.Dimension) / BaseDimension.ConvertValue(1, unit.BaseDimension);

        public double FromBaseValue(in double value)
            => Dimension.FromBaseValue(value) / _baseDimensionFromBaseValue;

        public double GetBaseValue(in double value)
            => Dimension.GetBaseValue(value) / _baseDimensionBaseValue;

        public override bool Equals(object? obj)
            => obj is ComposedUnit<TDimension, TBaseDimension> other
            && Dimension.Equals(other.Dimension)
            && BaseDimension.Equals(other.BaseDimension);

        public override int GetHashCode()
            => HashCode.Combine(Dimension.GetHashCode(), BaseDimension.GetHashCode());
    }
}
