using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Persistence
{
    public class CustomerContextSeed
    {
        public static async Task SeedAsync(CustomerContext CustomerContext, ILogger<CustomerContextSeed> logger)
        {
            if (!CustomerContext.Customers.Any())
            {
                logger.LogInformation($"Seed database associated with context {typeof(CustomerContext).Name}");
            }
        }
    }
}
