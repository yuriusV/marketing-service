using Notification.Application.Contracts.Persistence;
using Notification.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Notification.Application.Contracts;
using Notification.Infrastructure.Simplified.Services;

namespace Notification.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Stores in-memory data
        services.AddSingleton<INotificationRepository, NotificationRepository>();
        
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IGuidProvider, GuidProvider>();

        return services;
    }
}
