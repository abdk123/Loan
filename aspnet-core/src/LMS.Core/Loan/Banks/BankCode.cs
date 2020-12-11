using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Banks
{
    public class BankCode : FullAuditedEntity
    {
        public BankCode()
        {
        }

        [MaxLength(LMSConsts.MinStringLength)]
        public string Code { get; set; }

        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        public int CaseStatusId { get; set; }
        [ForeignKey("CaseStatusId")]
        public virtual CaseStatus CaseStatus
        {
            get; set;
        }

    }
}
