using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using PKS.BenchmarksRunner.Benchmarks.Config;
using PKS.BenchmarksRunner.Benchmarks.Infrastructure;

namespace PKS.BenchmarksRunner.Benchmarks.Application;

[MemoryDiagnoser, Config(typeof(BenchmarkConfig))]
public class SelectPostgresBenchmarks
{
    private const int Size = 50000;

    [Benchmark]
    public async Task<bool> Combined()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.CombinedTables.AsNoTracking()
            .OrderBy(x => x.CreatedOn)
            .Skip(Size)
            .Take(10_000)
            .Select(x => new {x.Id})
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> Int()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.IntTables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UlidBinary()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.UlidBinaryTables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UlidString()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.UlidStringTables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UuidV4()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.UuidV4Tables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UuidV7()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        await benchmarksDbContext.UuidV7Tables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(Size)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
}