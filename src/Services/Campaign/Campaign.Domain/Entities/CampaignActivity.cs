using Campaign.Domain.Common;

namespace Campaign.Domain.Entities;

public class CampaignActivity : EntityBase
{
    public CampaignActivity() { }

    public CampaignActivity(Guid id)
    {
        Id = id;
    }
    public Guid TargetId { get; set; }
}
