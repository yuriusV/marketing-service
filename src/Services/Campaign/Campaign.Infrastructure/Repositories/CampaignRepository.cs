using Campaign.Application.Contracts.Persistence;
using Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure.Repositories
{
    public class CampaignRepository : RepositoryBase<Domain.Entities.Campaign>, ICampaignRepository
    {
        public CampaignRepository(CampaignContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Campaign, bool>> predicate)
        {
            return await _dbContext.Campaigns
                .AnyAsync(predicate);
        }
    }
}
