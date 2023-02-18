using Microsoft.Extensions.DependencyInjection;
using ParkCinema.Application.Abstraction.Storage;
using ParkCinema.Infrastructure.Services;
using System.Data.SqlTypes;

namespace ParkCinema.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService,StorageService>();
    }
       public static void AddStorage<T>(this IServiceCollection services) where T:class,IStorage
    {
        services.AddScoped<IStorage,T>();
    }

    
}
