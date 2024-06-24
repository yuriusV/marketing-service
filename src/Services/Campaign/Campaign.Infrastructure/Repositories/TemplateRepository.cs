using Campaign.Application.Contracts.Persistence;
using Campaign.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Campaign.Infrastructure.Repositories
{
    public class TemplateRepository : RepositoryBase<Domain.Entities.Template>, ITemplateRepository
    {
        public TemplateRepository(CampaignContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Template, bool>> predicate)
        {
            return await _dbContext.Templates
                .AnyAsync(predicate);
        }
    }
}
