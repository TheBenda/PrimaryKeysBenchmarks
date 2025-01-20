using Microsoft.EntityFrameworkCore;
using PKS.Benchmarks.Migrations;
using PKS.Benchmarks.Migrations.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<Initializer>();

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<BenchmarksDbContext>("BenchmarkDb");
builder.AddSqlServerDbContext<BenchmarksSqlServerDbContext>("BenchmarkSqlServerDb");

builder.Services
    .AddOpenTelemetry()
    .WithTracing(t => t.AddSource(Initializer.ActivitySourceName));

var app = builder.Build();

app.Run();