using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Campaign.Infrastructure.Services.Quartz;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure.Services
{
    public class SchedulerService
    {
        private readonly ISchedulerFactory _schedulerFactory;

        public SchedulerService(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        public async Task AddCampaign(CampaignDto campaign)
        {
            //var scheduler = await _schedulerFactory.GetScheduler();

            //var job = JobBuilder.Create<DailyJob>()
            //                    .WithIdentity(campaign.Id.ToString(), "Campaigns")
            //                    .Build();

            //var trigger = TriggerBuilder.Create()
            //                            .WithIdentity(campaign.Id.ToString(), "Campaigns")
            //                            .StartNow()
            //                            .WithCronSchedule($"0 {campaign.Time.Minute} {campaign.Time.Hour} * * ?")
            //                            .Build();

            //await scheduler.ScheduleJob(job, trigger);
        }

        public async Task UpdateCampaign(Guid id, CampaignDto campaign)
        {
            //var scheduler = await _schedulerFactory.GetScheduler();
            //var jobKey = new JobKey(id.ToString(), "Campaigns");
            //var triggerKey = new TriggerKey(id.ToString(), "Campaigns");

            //await scheduler.DeleteJob(jobKey);

            //var job = JobBuilder.Create<DailyJob>()
            //                    .WithIdentity(id.ToString(), "Campaigns")
            //                    .Build();

            //var trigger = TriggerBuilder.Create()
            //                            .WithIdentity(id.ToString(), "Campaigns")
            //                            .StartNow()
            //                            .WithCronSchedule($"0 {campaign.Time.Minute} {campaign.Time.Hour} * * ?")
            //                            .Build();

            //await scheduler.ScheduleJob(job, trigger);
        }

        public async Task DeleteCampaign(Guid id)
        {
            var scheduler = await _schedulerFactory.GetScheduler();
            var jobKey = new JobKey(id.ToString(), "Campaigns");

            await scheduler.DeleteJob(jobKey);
        }
    }
}
