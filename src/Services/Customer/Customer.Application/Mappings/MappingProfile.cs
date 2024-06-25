using AutoMapper;
using Customer.Application.Features.Customers.Commands.CreateCustomer;
using Customer.Application.Features.Customers.Queries.GetCustomer;

namespace Customer.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Domain.Entities.Customer>()
            .ForMember(dest => dest.IsMale, opt => opt.MapFrom(src => src.IsMale))
            .ForMember(dest => dest.Deposit, opt => opt.MapFrom(src => src.Deposit))
            .ForMember(dest => dest.IsNewCustomer, opt => opt.MapFrom(src => src.IsNewCustomer))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
        CreateMap<Domain.Entities.Customer, CustomerDto>()
            .ForMember(dest => dest.IsMale, opt => opt.MapFrom(src => src.IsMale))
            .ForMember(dest => dest.Deposit, opt => opt.MapFrom(src => src.Deposit))
            .ForMember(dest => dest.IsNewCustomer, opt => opt.MapFrom(src => src.IsNewCustomer))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
    }
}
