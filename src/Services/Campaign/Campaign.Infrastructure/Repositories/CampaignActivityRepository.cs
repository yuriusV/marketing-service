using Campaign.Application.Contracts.Persistence;
using Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Campaign.Infrastructure.Repositories;

public class CampaignActivityRepository : RepositoryBase<Domain.Entities.CampaignActivity>, ICampaignActivityRepository
{
    public CampaignActivityRepository(CampaignContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.CampaignActivity, bool>> predicate)
    {
        return await _dbContext.Activities
            .AnyAsync(predicate);
    }
}
