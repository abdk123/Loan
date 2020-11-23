using Abp.Application.Services.Dto;
using LMS.Loan.Enums;

namespace LMS.Loan.Employees.Dto
{
    public class EmployeeDto:EntityDto
    {
        public string Name { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int EmployeeType { get; set; }
        public long UserId { get; set; }
    }
}
