using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Banks
{
    public class Bank : FullAuditedEntity
    {
        public Bank()
        {
            Codes = new List<BankCode>(); 
        }

        [MaxLength(LMSConsts.MinStringLength)]
        public string Name { get; set; }

        [MaxLength(LMSConsts.MinStringLength)]
        public string ForeignName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual IList<BankCode> Codes { get; set; }

    }
}
