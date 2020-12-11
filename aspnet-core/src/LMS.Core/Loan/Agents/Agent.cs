using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Agents
{
    public class Agent : FullAuditedEntity
    {
        public Agent()
        {
        }

        [MaxLength(LMSConsts.MinStringLength)]
        public string Name { get; set; }

        [MaxLength(LMSConsts.MinStringLength)]
        public string ForeignName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }


    }
}
