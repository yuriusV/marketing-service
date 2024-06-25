using Campaign.Application.Contracts.Services;
using Campaign.Infrastructure.Services.Quartz;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Campaign.Infrastructure.Services;

public class SchedulerService: ISchedulerService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly ILogger<SchedulerService> logger;

    public SchedulerService(ISchedulerFactory schedulerFactory, ILogger<SchedulerService> logger)
    {
        _schedulerFactory = schedulerFactory;
        this.logger = logger;
    }

    public async Task AddCampaignAsync(Domain.Entities.Campaign campaign)
    {
        logger.LogInformation("Scheduling campaign");
        var scheduler = await _schedulerFactory.GetScheduler();

        var job = JobBuilder.Create<DailyJob>()
            .WithIdentity(campaign.Id.ToString(), "Campaigns")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity(campaign.Id.ToString(), "Campaigns")
            .StartNow()
            .WithCronSchedule($"0 {campaign.Time.Minutes} {campaign.Time.Hours} * * ?")
            .Build();

        await scheduler.ScheduleJob(job, trigger);
    }

    public async Task UpdateCampaignAsync(Domain.Entities.Campaign campaign)
    {
        Guid id = campaign.Id;

        var scheduler = await _schedulerFactory.GetScheduler();
        var jobKey = new JobKey(id.ToString(), "Campaigns");

        await scheduler.DeleteJob(jobKey);

        var job = JobBuilder.Create<DailyJob>()
            .WithIdentity(id.ToString(), "Campaigns")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity(id.ToString(), "Campaigns")
            .StartNow()
            .WithCronSchedule($"0 {campaign.Time.Minutes} {campaign.Time.Hours} * * ?")
            .Build();

        await scheduler.ScheduleJob(job, trigger);
    }

    public async Task DeleteCampaignAsync(Guid id)
    {
        var scheduler = await _schedulerFactory.GetScheduler();
        var jobKey = new JobKey(id.ToString(), "Campaigns");

        await scheduler.DeleteJob(jobKey);
    }
}
