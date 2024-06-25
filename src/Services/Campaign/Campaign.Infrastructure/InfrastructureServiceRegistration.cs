using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services;
using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Application.Contracts.Services.NotificationsService;
using Campaign.Infrastructure.Persistence;
using Campaign.Infrastructure.Repositories;
using Campaign.Infrastructure.Services;
using Campaign.Infrastructure.Services.Http.CustomerApi;
using Campaign.Infrastructure.Services.Http.NotificationApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Campaign.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CampaignContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("CampaignConnectionString"));
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<ICampaignRepository, CampaignRepository>();
        services.AddScoped<ITemplateRepository, TemplateRepository>();
        services.AddScoped<ICampaignActivityRepository, CampaignActivityRepository>();

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.AddSingleton<ISchedulerService, SchedulerService>();
        services.AddTransient<ICustomersService, CustomersService>();
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<INotificationsService, NotificationService>();


        return services;
    }
}
