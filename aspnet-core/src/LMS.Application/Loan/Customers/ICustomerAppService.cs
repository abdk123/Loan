using Abp.Application.Services;
using LMS.Loan.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Loan.Customers
{
    public interface ICustomerAppService: IApplicationService
    {
        Task<IList<CustomerDto>> GetAllAsync();
        Task<IList<ReadCustomerDto>> GetAllForGridAsync();
        Task<CustomerDto> GetById(int id);
        Task<CustomerDto> CreateAsync(CreateCustomerDto input);
        Task<CustomerDto> UpdateAsync(UpdateCustomerDto input);
        Task DeleteAsync(int id);
    }
}
