namespace Campaign.Application.Aggregates.CampaignActivity;

public interface ICampaignActivityService
{
    Task CreateAsync(Guid campaignId);
}
