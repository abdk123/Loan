using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace LMS.Loan.Indexes
{
    public class Country: FullAuditedEntity
    {
        [MaxLength(LMSConsts.MaxIndexStringLength)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
