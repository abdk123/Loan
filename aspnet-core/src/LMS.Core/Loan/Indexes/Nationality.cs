using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Loan.Indexes
{
    public class Nationality : FullAuditedEntity
    {
        [MaxLength(LMSConsts.MaxIndexStringLength)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
