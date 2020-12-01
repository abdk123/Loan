using AutoMapper;
using LMS.Loan.Employees.Dto;
using LMS.Loan.Enums;

namespace LMS.Loan.Employees.Map
{
    public class EmployeeMap:Profile
    {
        public EmployeeMap()
        {
            CreateMap<EmployeeType, string>().ConvertUsing(src => src.ToString());
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, ReadEmployeeDto>();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
