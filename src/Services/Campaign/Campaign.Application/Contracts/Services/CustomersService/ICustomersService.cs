namespace Campaign.Application.Contracts.Services.CustomersService;

public interface ICustomersService
{
    public Task<IReadOnlyList<CustomerDto>> GetCustomersAsync(CustomersQuery query);
}
