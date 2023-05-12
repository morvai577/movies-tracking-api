using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Database;
using Movies.Application.Repositories;

namespace Movies.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        // Note this is actually a singleton masking a transient
        services.AddSingleton<IDbConnectionFactory>(new NpgsqlDbConnectionFactory(connectionString));
        services.AddSingleton<DbInitialiser>();
        return services;
    }
    
}