using Campaign.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure.Persistence
{
    public class CampaignContextSeed
    {
        public static async Task SeedAsync(CampaignContext campaignContext, ILogger<CampaignContextSeed> logger)
        {
            if (!campaignContext.Campaigns.Any())
            {
                campaignContext.Campaigns.AddRange(GetPreconfiguredCampaigns());
                await campaignContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(CampaignContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.Campaign> GetPreconfiguredCampaigns()
        {
            return new List<Domain.Entities.Campaign>
            {
                
            };
        }
    }
}
