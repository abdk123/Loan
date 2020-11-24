using LMS.Loan.Customers.Dto;

namespace LMS.Loan.Customers.Dto
{
    public class DeleteCustomerDto
    {
        public CustomerDto Key { get; set; }
        public string Action { get; set; }
    }
}
