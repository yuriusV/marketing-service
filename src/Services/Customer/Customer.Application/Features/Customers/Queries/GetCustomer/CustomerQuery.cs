using MediatR;
using System.Collections.Generic;

namespace Customer.Application.Features.Customers.Queries.GetCustomer
{
    public class CustomerQuery : CustomerDto, IRequest<IReadOnlyList<CustomerDto>>
    {
    }
}
