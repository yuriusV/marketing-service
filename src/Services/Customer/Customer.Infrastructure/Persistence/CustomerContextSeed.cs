using Microsoft.Extensions.Logging;

namespace Customer.Infrastructure.Persistence;

public class CustomerContextSeed
{
    public static async Task SeedAsync(CustomerContext customerContext, ILogger<CustomerContextSeed> logger)
    {
        if (!customerContext.Customers.Any())
        {
            customerContext.Customers.AddRange(GetPreconfiguredCustomers());
            await customerContext.SaveChangesAsync();
            logger.LogInformation($"Seed database associated with context {typeof(CustomerContext).Name}");
        }
    }

    private static IEnumerable<Domain.Entities.Customer> GetPreconfiguredCustomers()
    {
        Domain.Entities.Customer Get(int age, string gender, string city, decimal deposit, int newCustomer) =>
            new Domain.Entities.Customer
            {
                Birthdate = DateTime.UtcNow.AddYears(-age),
                IsMale = gender == "Male",
                City = city,
                Deposit = deposit,
                IsNewCustomer = newCustomer > 0,
            };

        return new List<Domain.Entities.Customer>
        {
            Get(53,"Male","London",104,0),
            Get(44,"Female","New York",209,1),
            Get(36,"Male","New York",208,1),
            Get(87,"Female","London",134,0),
            Get(54,"Male","Paris",123,1),
            Get(45,"Female","New York",210,1),
            Get(49,"Female","Tel-Aviv",174,0),
            Get(35,"Male","Paris",52,1),
            Get(61,"Male","Tel-Aviv",151,0),
            Get(78,"Male","Paris",57,0),
            Get(41,"Female","New York",131,0),
            Get(32,"Female","Tel-Aviv",154,1),
            Get(62,"Female","Paris",135,0),
            Get(67,"Male","Tel-Aviv",153,1),
            Get(68,"Female","London",241,1),
            Get(41,"Male","London",134,0),
            Get(46,"Female","London",212,0),
            Get(77,"Female","Tel-Aviv",97,1),
            Get(51,"Male","London",141,1),
            Get(80,"Male","Paris",189,0),
            Get(31,"Female","Tel-Aviv",134,1),
            Get(80,"Female","Tel-Aviv",81,0),
            Get(36,"Female","London",237,1),
            Get(65,"Female","Tel-Aviv",119,0),
            Get(72,"Male","Tel-Aviv",139,0),
            Get(64,"Male","Tel-Aviv",128,1),
            Get(29,"Male","London",76,1),
            Get(25,"Male","London",203,1),
            Get(77,"Male","New York",54,1),
            Get(79,"Female","Paris",165,1),
            Get(26,"Female","Paris",143,1),
            Get(74,"Female","London",61,0),
            Get(74,"Male","New York",103,0),
            Get(46,"Female","New York",121,1),
            Get(47,"Female","New York",214,0),
            Get(78,"Female","New York",111,0),
            Get(46,"Female","New York",223,1),
            Get(26,"Female","New York",78,1),
            Get(49,"Female","Tel-Aviv",60,0),
            Get(74,"Female","New York",53,1)
        };
    }
}
