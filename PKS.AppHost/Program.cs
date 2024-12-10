var builder = DistributedApplication.CreateBuilder(args);

var dataSource = builder.AddPostgres("PostgresDbConnection")
    .WithDataVolume()
    .AddDatabase("DataSourceDb");

builder.AddProject<Projects.PKS_Console>("Benchmarker")
    .WithReference(dataSource);

builder.Build().Run();