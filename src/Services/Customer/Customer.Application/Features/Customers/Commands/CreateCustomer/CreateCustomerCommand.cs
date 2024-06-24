using Customer.Application.Features.Customers.Queries.GetCustomer;
using MediatR;

namespace Customer.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public bool IsMale { get; set; }

    public string City { get; set; }

    public DateTime Birthdate { get; set; }

    public decimal Deposit { get; set; }

    public bool IsNewCustomer { get; set; }
}
