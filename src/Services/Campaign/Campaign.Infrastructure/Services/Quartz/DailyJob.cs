using Campaign.Application.Aggregates.CampaignActivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        using var scope = _serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<DailyJob>>();
        var taskId = context.JobDetail.Key.Name;
        logger.LogInformation($"Executing daily job: {taskId}");
        var campaignActivity = scope.ServiceProvider.GetRequiredService<ICampaignActivityService>();

        await campaignActivity.CreateAsync(Guid.Parse(taskId));
    }
}