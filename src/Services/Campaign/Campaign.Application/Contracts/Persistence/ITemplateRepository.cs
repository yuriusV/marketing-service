using System.Linq.Expressions;

namespace Campaign.Application.Contracts.Persistence;

public interface ITemplateRepository : IRepositoryBase<Domain.Entities.Template>
{
    Task<bool> AnyAsync(Expression<Func<Domain.Entities.Template, bool>> predicate);
}
