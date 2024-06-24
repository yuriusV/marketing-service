using Campaign.Application.Aggregates.CampaignActivity;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Application.Contracts.Services.NotificationsService;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Campaign.Infrastructure.Services.Quartz;

public class DailyJob : IJob
{
    private readonly IServiceProvider _serviceProvider;

    public DailyJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var campaignRepository = scope.ServiceProvider.GetRequiredService<ICampaignRepository>();
            var templateRepository = scope.ServiceProvider.GetRequiredService<ITemplateRepository>();

            var customersService = scope.ServiceProvider.GetRequiredService<ICustomersService>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationsService>();
            var campaignActivity = scope.ServiceProvider.GetRequiredService<ICampaignActivity>();

            var taskId = context.JobDetail.JobDataMap.GetString("TaskId");
            await campaignActivity.CreateAsync(Guid.Parse(taskId));
        }
}
}