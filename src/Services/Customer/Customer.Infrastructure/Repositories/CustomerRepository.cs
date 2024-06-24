using Customer.Application.Contracts.Persistence;
using Customer.Application.Features.Customers.Queries.GetCustomer;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Domain.Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Customer, bool>> predicate)
        {
            return await _dbContext.Customers
                .AnyAsync(predicate);
        }

        public Task<IReadOnlyList<Domain.Entities.Customer>> FindAsync(CustomerDto properties)
        {
            return GetAsync(x => 
                (properties.IsMale == null || x.IsMale == properties.IsMale)
                && (properties.Id == null || x.Id == properties.Id)
                && (properties.IsNewCustomer == null || x.IsNewCustomer == properties.IsNewCustomer)
                 && (properties.City == null || x.City == properties.City)
                  && (properties.Deposit == null || x.Deposit == properties.Deposit)
                   && (properties.Birthdate == null || x.Birthdate == properties.Birthdate));
        }
    }
}
