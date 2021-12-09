namespace CACTI.Units
{
    public interface IComposedUnit : IUnit
    {

    }

    public interface IComposedUnit<TDimension, TBaseDimension> : IUnit<IComposedUnit<TDimension, TBaseDimension>>, IComposedUnit
        where TDimension : IUnit<TDimension>
        where TBaseDimension : IUnit<TBaseDimension>

    {
        TDimension Dimension { get; }
        TBaseDimension BaseDimension { get; }
    }
}
