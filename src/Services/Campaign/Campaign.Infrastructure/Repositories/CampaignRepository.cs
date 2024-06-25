using Campaign.Application.Contracts.Persistence;
using Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Campaign.Infrastructure.Repositories;

public class CampaignRepository : RepositoryBase<Domain.Entities.Campaign>, ICampaignRepository
{
    public CampaignRepository(CampaignContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Domain.Entities.Campaign>> GetCampaignsWithTemplatesAsync()
    {
        return await _dbContext.Set<Domain.Entities.Campaign>().Include(x => x.Template).ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Campaign, bool>> predicate)
    {
        return await _dbContext.Campaigns
            .AnyAsync(predicate);
    }
}
