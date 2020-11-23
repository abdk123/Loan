using LMS.Loan.Employees.Dto;

namespace LMS.Loan.Employees.Dto
{
    public class DeleteEmployeeDto
    {
        public EmployeeDto Key { get; set; }
        public string Action { get; set; }
    }
}
