using LMS.Loan.Employees.Dto;
using System.Collections.Generic;

namespace LMS.Loan.Employees.Dto
{
    public class ReadEmployeeDto
    {
        public string name { get; set; }
        public string homePhone { get; set; }
        public string mobilePhone { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public int employeeType { get; set; }
    }
}
