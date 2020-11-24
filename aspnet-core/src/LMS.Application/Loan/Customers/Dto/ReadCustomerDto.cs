using LMS.Loan.Customers.Dto;
using System.Collections.Generic;

namespace LMS.Loan.Customers.Dto
{
    public class ReadCustomerDto
    {
        public string name { get; set; }
        public string homePhone { get; set; }
        public string mobilePhone { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public int employeeType { get; set; }
    }
}
