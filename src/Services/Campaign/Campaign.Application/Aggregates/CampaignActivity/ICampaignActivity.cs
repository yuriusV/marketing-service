namespace Campaign.Application.Aggregates.CampaignActivity;

public interface ICampaignActivity
{
    Task CreateAsync(Guid campaignId);
}
