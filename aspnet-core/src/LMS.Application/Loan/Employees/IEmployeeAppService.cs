using Abp.Application.Services;
using LMS.Crud.Dto;
using LMS.Loan.Employees.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Loan.Employees
{
    public interface IEmployeeAppService: IApplicationService
    {
        Task<IList<EmployeeDto>> GetAllAsync();
        Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm);
        Task<EmployeeDto> GetById(int id);
        Task<UpdateEmployeeDto> GetForEdit(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);
        Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input);
        Task DeleteAsync(int id);
    }
}
