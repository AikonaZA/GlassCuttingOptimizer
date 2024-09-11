using GlassCutting.Application.Services;
using GlassCutting.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GlassCutting.Application.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the SQLite database configuration to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the configuration to.</param>
    /// <returns>The IServiceCollection with the database configured.</returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICuttingOptimizer, CuttingOptimizerService>();

        return services;
    }
}
