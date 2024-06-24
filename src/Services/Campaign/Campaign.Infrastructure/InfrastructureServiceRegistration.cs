using Campaign.Application.Contracts.Persistence;
using Campaign.Infrastructure.Persistence;
using Campaign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure
{
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

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.UsePersistentStore(options =>
                {
                    options.UsePostgres(configuration.GetConnectionString("CampaignScheduleConnectionString"));
                    //options.UseJsonSerializer();
                    options.UseClustering();
                });
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }
    }
}
