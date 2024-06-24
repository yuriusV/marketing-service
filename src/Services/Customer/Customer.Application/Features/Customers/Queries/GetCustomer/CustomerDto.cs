namespace Customer.Application.Features.Customers.Queries.GetCustomer;

public class CustomerDto
{
    public Guid? Id { get; set; }

    public bool? IsMale { get; set; }

    public string? City { get; set; }

    public DateTime? Birthdate { get; set; }

    public decimal? Deposit { get; set; }

    public bool? IsNewCustomer { get; set; }
}
