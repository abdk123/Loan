using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [MaxLength(LMSConsts.MinStringLength)]
        public string Name { get; set; }

        [MaxLength(LMSConsts.MinStringLength)]
        public string ForeignName { get; set; }
        public string Number { get; set; }
        public DateTime? BirthDate { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
        public string PassportNumber { get; set; }

        [MaxLength(LMSConsts.MaxStringLength)]
        public string Address1 { get; set; }

        [MaxLength(LMSConsts.MaxStringLength)]
        public string Address2 { get; set; }
        public string City { get; set; }

        [MaxLength(LMSConsts.MinStringLength)]
        public string Email { get; set; }

        [MaxLength(LMSConsts.MaxStringLength)]
        public string Note { get; set; }
        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

    }
}
