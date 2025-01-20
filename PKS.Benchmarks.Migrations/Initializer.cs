using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OpenTelemetry.Trace;
using PKS.Benchmarks.Migrations.Data;
using PKS.Benchmarks.Migrations.Data.Seeding;

namespace PKS.Benchmarks.Migrations;

public class Initializer(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime
) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";
    private static readonly ActivitySource ActivitySource =
        new(ActivitySourceName);
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(
            "Migrating database",
            ActivityKind.Client
        );

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BenchmarksDbContext>();
            var sqlServerDbContext = scope.ServiceProvider.GetRequiredService<BenchmarksSqlServerDbContext>();
            
            await EnsurePostgresDatabaseAsync(dbContext, stoppingToken);
            await EnsureSqlServerDatabaseAsync(sqlServerDbContext, stoppingToken);
            await MigratePostgresBenchmarkDatabase(dbContext, stoppingToken);
            await MigrateSqlServerBenchmarkDatabase(sqlServerDbContext, stoppingToken);
            await SeedPostgresBenchmarkDatabase(dbContext, stoppingToken);
            await SeedSqlServerBenchmarkDatabase(sqlServerDbContext, stoppingToken);
        }
        catch (Exception e)
        {
            activity?.RecordException(e);
            throw;
        }
        
        hostApplicationLifetime.StopApplication();
    }

    private async Task SeedPostgresBenchmarkDatabase(BenchmarksDbContext dbContext, CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(
            "Seeding Postgres Benchmark database",
            ActivityKind.Client
        );
        
        await dbContext.SeedPostgresData(stoppingToken);
    }
    
    private async Task SeedSqlServerBenchmarkDatabase(BenchmarksSqlServerDbContext dbContext, CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(
            "Seeding SqlServer Benchmark database",
            ActivityKind.Client
        );
        
        await dbContext.SeedSqlServerData(stoppingToken);
    }

    private async Task MigratePostgresBenchmarkDatabase(BenchmarksDbContext dbContext, CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(
            "Migrating Postgres database",
            ActivityKind.Client
        );
        
        await dbContext.Database.MigrateAsync(stoppingToken);
    }
    
    private async Task MigrateSqlServerBenchmarkDatabase(BenchmarksSqlServerDbContext dbContext, CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(
            "Migrating SqlServer database",
            ActivityKind.Client
        );
        
        await dbContext.Database.MigrateAsync(stoppingToken);
    }

    private static async Task EnsurePostgresDatabaseAsync(
        BenchmarksDbContext context,
        CancellationToken cancellationToken
    )
    {
        var dbCreator = context.GetService<IRelationalDatabaseCreator>();

        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Create the database if it does not exist.
            // Do this first so there is then a database to start a transaction against.
            if (!await dbCreator.ExistsAsync(cancellationToken))
            {
                await dbCreator.CreateAsync(cancellationToken);
            }
        });
    }
    
    private static async Task EnsureSqlServerDatabaseAsync(
        BenchmarksSqlServerDbContext context,
        CancellationToken cancellationToken
    )
    {
        var dbCreator = context.GetService<IRelationalDatabaseCreator>();

        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Create the database if it does not exist.
            // Do this first so there is then a database to start a transaction against.
            if (!await dbCreator.ExistsAsync(cancellationToken))
            {
                await dbCreator.CreateAsync(cancellationToken);
            }
        });
    }
    
    // private async Task RunMigrationsAsync(BenchmarksDbContext dbContext, CancellationToken stoppingToken)
    // {
    //     var strategy = dbContext.Database.CreateExecutionStrategy();
    //     await strategy.ExecuteAsync(async () =>
    //     {
    //         // Run migration in a transaction to avoid partial migration if it fails.
    //         await using var transaction =
    //             await dbContext.Database.BeginTransactionAsync(
    //                 stoppingToken
    //             );
    //         await dbContext.Database.MigrateAsync(stoppingToken);
    //         await transaction.CommitAsync(stoppingToken);
    //     });
    // }
}