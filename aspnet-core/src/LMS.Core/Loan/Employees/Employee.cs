using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Users;
using LMS.Loan.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Loan.Employees
{
    public class Employee:FullAuditedEntity
    {
        [MaxLength(LMSConsts.MinStringLength)]
        public string Name { get; set; }
        [MaxLength(LMSConsts.MinStringLength)]
        public string HomePhone { get; set; }
        [MaxLength(LMSConsts.MinStringLength)]
        public string MobilePhone { get; set; }
        [MaxLength(LMSConsts.MaxStringLength)]
        public string Address { get; set; }

        [MaxLength(LMSConsts.MinStringLength)]
        public string EmailAddress { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }

    }
}
