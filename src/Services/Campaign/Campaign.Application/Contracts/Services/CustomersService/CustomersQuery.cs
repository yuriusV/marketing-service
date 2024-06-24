using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Services.CustomersService
{
    public class CustomersQuery
    {
        public QueryExpression Id { get; set; }

        public QueryExpression IsMale { get; set; }

        public QueryExpression City { get; set; }

        public QueryExpression Birthdate { get; set; }

        public QueryExpression Deposit { get; set; }

        public QueryExpression IsNewCustomer { get; set; }
    }
}
