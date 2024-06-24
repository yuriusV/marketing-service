using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Aggregates.CampaignActivity
{
    public interface ICampaignActivity
    {
        Task CreateAsync(Guid campaignId);
    }
}
