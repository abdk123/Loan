using Abp.Application.Services;
using LMS.Loan.Employees.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Loan.Employees
{
    public interface IEmployeeAppService: IApplicationService
    {
        Task<IList<EmployeeDto>> GetAllAsync();
        Task<IList<ReadEmployeeDto>> GetAllForGridAsync();
        Task<EmployeeDto> GetById(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);
        Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input);
        Task DeleteAsync(int id);
    }
}
