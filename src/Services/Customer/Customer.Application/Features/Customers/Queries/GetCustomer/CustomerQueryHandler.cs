﻿using AutoMapper;
using Customer.Application.Contracts.Persistence;
using MediatR;

namespace Customer.Application.Features.Customers.Queries.GetCustomer;

public class CustomerQueryHandler : IRequestHandler<CustomerQuery, IReadOnlyList<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CustomerDto>> Handle(CustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindAsync(request);
        return _mapper.Map<IReadOnlyList<CustomerDto>>(customer)!;
    }
}
