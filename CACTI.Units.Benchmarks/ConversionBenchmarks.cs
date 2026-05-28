using BenchmarkDotNet.Attributes;
using CACTI.Units.Distances;
using CACTI.Units.Speeds;
using CACTI.Units.Accelerations;

namespace CACTI.Units.Benchmarks;

[MemoryDiagnoser]
public class ConversionBenchmarks
{
    private Distance _distance;
    private Speed _speed;

    [GlobalSetup]
    public void Setup()
    {
        _distance = new Distance(1500, DistanceDimension.Meter);
        _speed = new Speed(100, SpeedDimension.KilometerPerHour);
    }

    [Benchmark]
    public double SimpleConversion()
        => _distance.ConvertValue(DistanceDimension.Kilometer);

    [Benchmark]
    public double ComposedConversion()
        => _speed.ConvertValue(SpeedDimension.MeterPerSecond);

    [Benchmark]
    public double GetBaseValue_Simple()
        => DistanceDimension.Kilometer.GetBaseValue(42.0);

    [Benchmark]
    public double GetBaseValue_Composed()
        => SpeedDimension.KilometerPerHour.GetBaseValue(120.0);

    [Benchmark]
    public double FromBaseValue_Composed()
        => SpeedDimension.KilometerPerHour.FromBaseValue(33.33);

    [Benchmark]
    public Distance Convert_DistanceUnit()
        => _distance.Convert(DistanceDimension.Kilometer);
}
