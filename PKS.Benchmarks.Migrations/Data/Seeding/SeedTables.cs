using EFCore.BulkExtensions;
using PKS.Benchmarks.Domain.Entities;

namespace PKS.Benchmarks.Migrations.Data.Seeding;

internal static class SeedTables
{
    private const int Size = 100000;

    internal static async Task<bool> SeedSqlServerData(this BenchmarksSqlServerDbContext context,
        CancellationToken cancellationToken = default)
    {
        if (!context.CombinedTables.Any())
            await context.SeedCombinedPerson(cancellationToken);
        if (!context.IntTables.Any())
            await context.SeedIntPerson(cancellationToken);
        if (!context.UlidBinaryTables.Any())
            await context.SeedUlidBinaryPerson(cancellationToken);
        if (!context.UlidStringTables.Any())
            await context.SeedUlidStringPerson(cancellationToken);
        if (!context.UuidV4Tables.Any())
            await context.SeedUuidV4Person(cancellationToken);
        if (!context.UuidV7Tables.Any())
            await context.SeedUuidV7Person(cancellationToken);
        if (!context.UuidV7BinaryTables.Any())
            await context.SeedUuidV7BinaryPerson(cancellationToken);
        if (!context.UuidV8Tables.Any())
            await context.SeedUuidV8Person(cancellationToken);
        return true;
    }

    internal static async Task<bool> SeedPostgresData(this BenchmarksDbContext context, CancellationToken cancellationToken)
    {
        if (!context.CombinedTables.Any())
            await context.SeedCombinedPerson(cancellationToken);
        if (!context.IntTables.Any())
            await context.SeedIntPerson(cancellationToken);
        if (!context.UlidBinaryTables.Any())
            await context.SeedUlidBinaryPerson(cancellationToken);
        if (!context.UlidStringTables.Any())
            await context.SeedUlidStringPerson(cancellationToken);
        if (!context.UuidV4Tables.Any())
            await context.SeedUuidV4Person(cancellationToken);
        if (!context.UuidV7Tables.Any())
            await context.SeedUuidV7Person(cancellationToken);
        return true;
    }

    private static async Task<bool> SeedCombinedPerson(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<CombinedTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(CombinedTable.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedIntPerson(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        for (var i = 0; i < Size; i++)
        {
            benchmarksDbContext.IntTables.Add(IntTable.Random());
        }
        await benchmarksDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUlidBinaryPerson(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UlidBinaryTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidBinaryTable.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUlidStringPerson(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UlidStringTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidStringTable.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUuidV4Person(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV4Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV4Table.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUuidV7Person(this BenchmarksDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV7Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV7Table.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }
    
    private static async Task<bool> SeedCombinedPerson(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<CombinedTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(CombinedTable.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedIntPerson(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        for (var i = 0; i < Size; i++)
        {
            benchmarksDbContext.IntTables.Add(IntTable.Random());
        }
        await benchmarksDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUlidBinaryPerson(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UlidBinaryTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidBinaryTable.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUlidStringPerson(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UlidStringTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UlidStringTable.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUuidV4Person(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV4Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV4Table.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }

    private static async Task<bool> SeedUuidV7Person(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV7Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV7Table.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }
    
    private static async Task<bool> SeedUuidV7BinaryPerson(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV7BinaryTable>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV7BinaryTable.Random(DateTimeOffset.UtcNow.AddMilliseconds(i)));
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }
    
    private static async Task<bool> SeedUuidV8Person(this BenchmarksSqlServerDbContext benchmarksDbContext, CancellationToken cancellationToken)
    {
        var entitiesToInsert = new List<UuidV8Table>();
        for (var i = 0; i < Size; i++)
        {
            entitiesToInsert.Add(UuidV8Table.Random());
        }
        await benchmarksDbContext.BulkInsertAsync(entitiesToInsert, cancellationToken: cancellationToken);
        return true;
    }
}