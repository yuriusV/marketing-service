﻿namespace Campaign.Domain.Entities;

public class CustomerQuery
{
    public QueryExpression? Id { get; set; }

    public QueryExpression? IsMale { get; set; }

    public QueryExpression? City { get; set; }

    public QueryExpression? Birthdate { get; set; }

    public QueryExpression? Deposit { get; set; }

    public QueryExpression? IsNewCustomer { get; set; }
}
