using BenchmarkDotNet.Attributes;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PKS.Benchmarks.Domain.Entities;
using PKS.BenchmarksRunner.Benchmarks.Config;
using PKS.BenchmarksRunner.Benchmarks.Infrastructure;

namespace PKS.BenchmarksRunner.Benchmarks.Application;

[MemoryDiagnoser, Config(typeof(BenchmarkConfig))]
public class SpecialBenchmarks
{
    [Benchmark]
    public async Task<bool> InitialSelectV8()
    {
        await using var benchmarksDbContext = new BenchmarksSqlServerDbContext();
        await benchmarksDbContext.UuidV8Tables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(50000)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> InsertV8()
    {
        await using var benchmarksDbContext = new BenchmarksSqlServerDbContext();
        var entitiesToInsert = new List<UuidV8Table>();
        for (var i = 0; i < 200000; i++)
        {
            entitiesToInsert.Add(UuidV8Table.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
    
    [Benchmark]
    public async Task<bool> SelectV8()
    {
        await using var benchmarksDbContext = new BenchmarksSqlServerDbContext();
        await benchmarksDbContext.UuidV8Tables.AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip(50000)
            .Take(10_000)
            .ToListAsync();
        return true;
    }
}