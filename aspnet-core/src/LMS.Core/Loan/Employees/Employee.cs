using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Users;
using LMS.Loan.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Employees
{
    public class Employee:FullAuditedEntity
    {
        public string Name { get; set; } 
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
         
    }
}
