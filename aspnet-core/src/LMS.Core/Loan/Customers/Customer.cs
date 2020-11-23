using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Customers
{
    public class Customer : FullAuditedEntity
    {
        public Customer()
        {
            //Cases = new List<Case>();
        }
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
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

    }
}
