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

        public Task<IReadOnlyList<Domain.Entities.Customer>> FindAsync(CustomerQuery properties)
        {
            var parameter = Expression.Parameter(typeof(Domain.Entities.Customer), "x");

            Expression filterExpression = Expression.Constant(true);

            BinaryExpression GetExpression(string column, string filter, object value)
            {
                var prop = Expression.Property(parameter, column);
                var constant = Expression.Constant(value);

                return filter switch
                {
                    "=" => Expression.Equal(prop, constant),
                    ">" => Expression.GreaterThan(prop, constant),
                    "<" => Expression.LessThan(prop, constant),
                    _ => throw new ArgumentException("Unsupported function name")
                };
            }

            if (properties.Id != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.Id), properties.Id.Function, Guid.Parse(properties.Id.Value)));
            }

            if (properties.IsMale != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.IsMale), properties.IsMale.Function, bool.Parse(properties.IsMale.Value)));
            }

            if (properties.IsNewCustomer != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.IsNewCustomer), properties.IsNewCustomer.Function, bool.Parse(properties.IsNewCustomer.Value)));
            }

            if (properties.City != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.City), properties.City.Function, properties.City.Value));
            }

            if (properties.Birthdate != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.Birthdate), properties.Birthdate.Function, DateTime.Parse(properties.Birthdate.Value)));
            }

            if (properties.Deposit != null)
            {
                filterExpression = Expression.AndAlso(
                    filterExpression,
                    GetExpression(nameof(properties.Deposit), properties.Deposit.Function, decimal.Parse(properties.Deposit.Value)));
            }

            var lambda = Expression.Lambda<Func<Domain.Entities.Customer, bool>>(filterExpression, parameter);

            return GetAsync(lambda);
        }
    }
}
