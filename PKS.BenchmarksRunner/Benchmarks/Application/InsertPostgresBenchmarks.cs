using BenchmarkDotNet.Attributes;
using EFCore.BulkExtensions;
using PKS.Benchmarks.Domain.Entities;
using PKS.BenchmarksRunner.Benchmarks.Config;
using PKS.BenchmarksRunner.Benchmarks.Infrastructure;

namespace PKS.BenchmarksRunner.Benchmarks.Application;

[MemoryDiagnoser, Config(typeof(BenchmarkConfig))]
public class InsertPostgresBenchmarks
{
    private const int Size = 100000;
    
    [Benchmark]
    public async Task<bool> Combined()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        var entitiesToInsert = new List<CombinedTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(CombinedTable.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
    
    [Benchmark]
    public async Task<bool> Int()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        for (var i = 0; i < Size; i++)
        {
            benchmarksDbContext.IntTables.Add(IntTable.Random());
        }
        await benchmarksDbContext.SaveChangesAsync();
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UlidBinary()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        var entitiesToInsert = new List<UlidBinaryTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidBinaryTable.Random(DateTimeOffset.UtcNow.AddMinutes(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UlidString()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        var entitiesToInsert = new List<UlidStringTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidStringTable.Random(DateTimeOffset.UtcNow.AddMinutes(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UuidV4()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        var entitiesToInsert = new List<UuidV4Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV4Table.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
    
    [Benchmark]
    public async Task<bool> UuidV7()
    {
        await using var benchmarksDbContext = new BenchmarksDbContext();
        var entitiesToInsert = new List<UuidV7Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV7Table.Random(DateTimeOffset.UtcNow.AddMinutes(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert);
        return true;
    }
}