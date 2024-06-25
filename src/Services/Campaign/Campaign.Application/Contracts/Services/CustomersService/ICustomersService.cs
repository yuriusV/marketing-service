using Campaign.Domain.Entities;

namespace Campaign.Application.Contracts.Services.CustomersService;

public interface ICustomersService
{
    public Task<IReadOnlyList<CustomerDto>> GetCustomersAsync(CustomerQuery query);
}
