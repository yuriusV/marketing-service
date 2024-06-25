using System.Linq.Expressions;

namespace Campaign.Application.Contracts.Persistence;

public interface ICampaignRepository : IRepositoryBase<Domain.Entities.Campaign>
{
    Task<IReadOnlyList<Domain.Entities.Campaign>> GetCampaignsWithTemplatesAsync();

    Task<bool> AnyAsync(Expression<Func<Domain.Entities.Campaign, bool>> predicate);
}
