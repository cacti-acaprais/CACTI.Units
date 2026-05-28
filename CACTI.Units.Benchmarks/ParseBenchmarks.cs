using BenchmarkDotNet.Attributes;
using CACTI.Units.Distances;
using CACTI.Units.Speeds;

namespace CACTI.Units.Benchmarks;

[MemoryDiagnoser]
public class ParseBenchmarks
{
    [Benchmark]
    public Distance? BaseUnit_TryParse()
        => Distance.Parse("10.5 km");

    [Benchmark]
    public Kilometer? SpecializedUnit_TryParse()
        => Kilometer.Parse("10.5 km");

    [Benchmark]
    public Speed? ComposedUnit_TryParse()
        => Speed.Parse("120 km/h");

    [Benchmark]
    public bool Dimension_TryParse()
        => DistanceDimension.TryParse("km", out _);
}
