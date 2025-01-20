using Microsoft.AspNetCore.Identity;
using PKS.IdentityApi.Domain.Entities;
using PKS.IdentityApi.Infrastructure.Data;


namespace PKS.IdentityApi.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<IdentityUserDbContext>("DataSourceDb");
        return builder;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<IdentityUserDbContext>()
            .AddApiEndpoints();
        
        return services;
    }
}