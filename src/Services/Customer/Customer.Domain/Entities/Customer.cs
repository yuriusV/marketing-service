using Customer.Domain.Common;

namespace Customer.Domain.Entities;

public class Customer : EntityBase
{
    public Guid Id { get; set; }

    public bool IsMale { get; set; }

    public string City { get; set; }

    public DateTime Birthdate { get; set; }

    public decimal Deposit { get; set; }

    public bool IsNewCustomer { get; set; }
}
