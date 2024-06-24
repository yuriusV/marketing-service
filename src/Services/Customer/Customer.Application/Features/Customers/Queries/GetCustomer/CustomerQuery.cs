using MediatR;
using System.Collections.Generic;

namespace Customer.Application.Features.Customers.Queries.GetCustomer
{
    public class CustomerQuery : IRequest<IReadOnlyList<CustomerDto>>
    {
        public QueryExpression? Id { get; set; }

        public QueryExpression? IsMale { get; set; }

        public QueryExpression? City { get; set; }

        public QueryExpression? Birthdate { get; set; }

        public QueryExpression? Deposit { get; set; }

        public QueryExpression? IsNewCustomer { get; set; }
    }
}
