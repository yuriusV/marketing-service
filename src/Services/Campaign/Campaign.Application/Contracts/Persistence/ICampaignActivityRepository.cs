using System.Linq.Expressions;

namespace Campaign.Application.Contracts.Persistence;

public interface ICampaignActivityRepository : IRepositoryBase<Domain.Entities.CampaignActivity>
{
    Task<bool> AnyAsync(Expression<Func<Domain.Entities.CampaignActivity, bool>> predicate);
}
