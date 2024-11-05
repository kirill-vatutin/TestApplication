using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.Application.IRepositories;
using TestApplication.Infrastructure.Repositories;

namespace TestApplication.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}
