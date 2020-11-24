using AutoMapper;
using LMS.Loan.Customers.Dto;

namespace LMS.Loan.Customers.Map
{
    public class CustomerMap:Profile
    {
        public CustomerMap()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, ReadCustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
