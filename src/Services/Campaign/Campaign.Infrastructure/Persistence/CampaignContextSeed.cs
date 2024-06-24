using Microsoft.Extensions.Logging;
using System.Text;

namespace Campaign.Infrastructure.Persistence
{
    public class CampaignContextSeed
    {
        public static async Task SeedAsync(CampaignContext campaignContext, ILogger<CampaignContextSeed> logger)
        {
            if (!campaignContext.Templates.Any())
            {
                campaignContext.Templates.AddRange(GetPreconfiguredTemplates());
                await campaignContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(CampaignContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.Template> GetPreconfiguredTemplates()
        {
            return new List<Domain.Entities.Template>
            {
                new Domain.Entities.Template { Name = "Template A", Contents = Encoding.UTF8.GetBytes("Template A") },
                new Domain.Entities.Template { Name = "Template B", Contents = Encoding.UTF8.GetBytes("Template B") },
                new Domain.Entities.Template { Name = "Template C", Contents = Encoding.UTF8.GetBytes("Template C") }
            };
        }
    }
}
