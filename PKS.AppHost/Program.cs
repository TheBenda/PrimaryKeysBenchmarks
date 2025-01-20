var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("SqlServerDbConnection")
    .WithDataVolume()
    .WithExternalHttpEndpoints()
    .WithLifetime(ContainerLifetime.Persistent);

var sqlServerDb = sqlServer.AddDatabase("BenchmarkSqlServerDb");

var postgres = builder.AddPostgres("PostgresDbConnection")
    .WithDataVolume()
    .WithOtlpExporter()
    .WithPgWeb()
    .WithExternalHttpEndpoints()
    .WithLifetime(ContainerLifetime.Persistent);

var postgresDb = postgres.AddDatabase("BenchmarkDb");

var migrations = builder.AddProject<Projects.PKS_Benchmarks_Migrations>("BenchmarksMigrations")
    .WithReference(postgresDb)
    .WithReference(sqlServerDb)
    .WaitFor(sqlServerDb)
    .WaitFor(postgresDb);

builder.Build().Run();