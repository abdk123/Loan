using Abp.Application.Services.Dto;
using LMS.Loan.Enums;
using System;

namespace LMS.Loan.Customers.Dto
{
    public class CustomerDto:EntityDto
    {
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string Number { get; set; }
        public DateTime? BirthDate { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
        public string PassportNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public int NationalityId { get; set; }
        public int CountryId { get; set; }
    }
}
