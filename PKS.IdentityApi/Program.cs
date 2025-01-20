using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PKS.IdentityApi.Domain.Entities;
using PKS.IdentityApi.Infrastructure.Data;
using PKS.IdentityApi.Infrastructure.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorization();

builder.AddInfrastructure();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {
        options.WithTitle("Identity API")
            .WithDownloadButton(true)
            .WithTheme(ScalarTheme.Moon)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
    
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
    
    using var scope = app.Services.CreateScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<IdentityUserDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.MapGet("/hello", () => Results.Ok("hello world"));

app.UseHttpsRedirection();
app.MapIdentityApi<User>();

app.Run();
