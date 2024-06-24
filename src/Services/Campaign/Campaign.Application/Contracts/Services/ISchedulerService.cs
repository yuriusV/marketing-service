using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Services
{
    public interface ISchedulerService
    {
        Task AddCampaignAsync(Domain.Entities.Campaign campaign);

        Task UpdateCampaignAsync(Domain.Entities.Campaign campaign);

        Task DeleteCampaignAsync(Guid id);
    }
}
