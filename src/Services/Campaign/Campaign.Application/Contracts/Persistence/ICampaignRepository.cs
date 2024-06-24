using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Persistence
{
    public interface ICampaignRepository : IRepositoryBase<Domain.Entities.Campaign>
    {
        Task<bool> AnyAsync(Expression<Func<Domain.Entities.Campaign, bool>> predicate);
    }
}
