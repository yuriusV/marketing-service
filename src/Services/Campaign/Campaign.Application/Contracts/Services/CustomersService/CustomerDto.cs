using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Services.CustomersService
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public bool IsMale { get; set; }

        public string City { get; set; }

        public DateTime Birthdate { get; set; }

        public decimal Deposit { get; set; }

        public bool IsNewCustomer { get; set; }
    }
}
