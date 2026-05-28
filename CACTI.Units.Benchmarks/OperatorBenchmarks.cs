using BenchmarkDotNet.Attributes;
using CACTI.Units.Distances;
using CACTI.Units.Durations;
using CACTI.Units.Speeds;
using CACTI.Units.Ratios;

namespace CACTI.Units.Benchmarks;

[MemoryDiagnoser]
public class OperatorBenchmarks
{
    private Distance _d1;
    private Distance _d2;
    private Kilometer _km1;
    private Kilometer _km2;
    private Ratio _ratio;

    [GlobalSetup]
    public void Setup()
    {
        _d1 = new Distance(100, DistanceDimension.Meter);
        _d2 = new Distance(1.5, DistanceDimension.Kilometer);
        _km1 = new Kilometer(5);
        _km2 = new Kilometer(3);
        _ratio = new Ratio(0.1);
    }

    [Benchmark]
    public Distance Add_BaseUnits()
        => _d1 + _d2;

    [Benchmark]
    public Kilometer Add_SpecializedUnits()
        => _km1 + _km2;

    [Benchmark]
    public bool Compare_BaseUnits()
        => _d1 > _d2;

    [Benchmark]
    public bool Equals_BaseUnits()
        => _d1 == _d2;

    [Benchmark]
    public Ratio Divide_SameUnit()
        => _d1 / _d2;

    [Benchmark]
    public Distance Multiply_ByScalar()
        => _d1 * 2.5;

    [Benchmark]
    public Distance Apply_Ratio()
        => _d1 * _ratio;

    [Benchmark]
    public int GetHashCode_BaseUnit()
        => _d1.GetHashCode();

    [Benchmark]
    public int GetHashCode_SpecializedUnit()
        => _km1.GetHashCode();
}
