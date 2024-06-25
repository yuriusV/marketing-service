using Customer.Application.Contracts.Persistence;
using Customer.Application.Features.Customers.Queries.GetCustomer;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.Infrastructure.Repositories;

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
        properties = properties ?? throw new ArgumentNullException(nameof(properties));

        var parameter = Expression.Parameter(typeof(Domain.Entities.Customer), "x");
        Expression filterExpression = BuildSearchExpression(properties, parameter);

        var lambda = Expression.Lambda<Func<Domain.Entities.Customer, bool>>(filterExpression, parameter);

        return GetAsync(lambda);
    }

    private static Expression BuildSearchExpression(CustomerQuery properties, ParameterExpression parameter)
    {
        Expression filterExpression = Expression.Constant(true);

        // TODO: make parsing safier, add validation
        if (properties.Id != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.Id), properties.Id.Function, Guid.Parse(properties.Id.Value), parameter));
        }

        if (properties.IsMale != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.IsMale), properties.IsMale.Function, bool.Parse(properties.IsMale.Value), parameter));
        }

        if (properties.IsNewCustomer != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.IsNewCustomer), properties.IsNewCustomer.Function, bool.Parse(properties.IsNewCustomer.Value), parameter));
        }

        if (properties.City != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.City), properties.City.Function, properties.City.Value, parameter));
        }

        if (properties.Birthdate != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.Birthdate), properties.Birthdate.Function, DateTime.Parse(properties.Birthdate.Value), parameter));
        }

        if (properties.Deposit != null)
        {
            filterExpression = Expression.AndAlso(
                filterExpression,
                GetExpression(nameof(properties.Deposit), properties.Deposit.Function, decimal.Parse(properties.Deposit.Value), parameter));
        }

        return filterExpression;
    }

    private static BinaryExpression GetExpression(string column, string filter, object value, ParameterExpression? parameter)
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
}
