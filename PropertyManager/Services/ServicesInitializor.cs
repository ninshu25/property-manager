using DataAccess.Access;
using DataAccess.Repositories;
using Interfaces.Repositories;
using Interfaces.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain;
using Services.System;
using Services.SystemServices;

namespace Services;

public static class ServicesInitializor
{
    public static void ConfigureAllServices(this IServiceCollection services, IConfiguration config)
    {
        ConfigureEssentialServices(services);
        ConfigureDomainServices(services);
        ConfigureRepositories(services);
    }

    internal static void ConfigureEssentialServices(this IServiceCollection services)
    {
        services.AddScoped<IDataAccessService, DataAccessService>();
        services.AddScoped<IFactoryService, FactoryService>();
        services.AddScoped<ILoggingService, LoggingService>();
        services.AddScoped<ISessionService, SessionService>();
    }

    internal static void ConfigureDomainServices(this IServiceCollection services)
    {
        // The below is an example of where to initialize each domain service
        services.AddScoped<IContactsService, ContactsService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IPropertyOwnershipService, PropertyOwnershipService>();
        services.AddScoped<IDashboardService, DashboardService>();
    }


    internal static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IContactsRepository, ContactsRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IPropertyOwnershipRepository, PropertyOwnershipRepository>();
    }
}