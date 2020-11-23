using AutoMapper;
using LMS.Loan.Employees.Dto;

namespace LMS.Loan.Employees.Map
{
    public class EmployeeMap:Profile
    {
        public EmployeeMap()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, ReadEmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
