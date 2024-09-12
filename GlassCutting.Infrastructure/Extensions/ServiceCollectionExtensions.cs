using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using GlassCutting.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GlassCutting.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the SQLite database configuration to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the configuration to.</param>
    /// <param name="connectionString">The SQLite connection string.</param>
    /// <returns>The IServiceCollection with the database configured.</returns>
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString)); // Configure SQLite with the provided connection string

        // Register repositories and other related services
        services.AddScoped<IStockSheetRepository, StockSheetRepository>();
        services.AddScoped<IGlassPanelRepository, GlassPanelRepository>();
        services.AddScoped<IDatabaseRepository, DatabaseRepository>();

        return services;
    }
}