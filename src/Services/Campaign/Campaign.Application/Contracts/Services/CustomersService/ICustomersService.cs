using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Contracts.Services.CustomersService
{
    public interface ICustomersService
    {
        public Task<IReadOnlyList<CustomerDto>> GetCustomersAsync(CustomersQuery query);
    }
}
