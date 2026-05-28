using BenchmarkDotNet.Attributes;
using CACTI.Units.Distances;
using CACTI.Units.Speeds;
using CACTI.Units.Ratios;

namespace CACTI.Units.Benchmarks;

[MemoryDiagnoser]
public class ToStringBenchmarks
{
    private Distance _distance;
    private Kilometer _kilometer;
    private Speed _speed;
    private Ratio _ratio;

    [GlobalSetup]
    public void Setup()
    {
        _distance = new Distance(42.5, DistanceDimension.Kilometer);
        _kilometer = new Kilometer(42.5);
        _speed = new Speed(120, SpeedDimension.KilometerPerHour);
        _ratio = new Ratio(0.85);
    }

    [Benchmark]
    public string BaseUnit_ToString()
        => _distance.ToString();

    [Benchmark]
    public string BaseUnit_ToString_WithFormat()
        => _distance.ToString("F2");

    [Benchmark]
    public string SpecializedUnit_ToString()
        => _kilometer.ToString();

    [Benchmark]
    public string ComposedUnit_ToString()
        => _speed.ToString();

    [Benchmark]
    public string Ratio_ToString()
        => _ratio.ToString();
}
