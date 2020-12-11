using Abp.Domain.Entities.Auditing;
using LMS.Loan.Employees;
using LMS.Loan.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Workflows
{
    public class WorkflowStep : FullAuditedEntity
    {
        public int Order { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public StepStatus StepStatus { get; set; }
        public int WorkflowItemId { get; set; }
        [ForeignKey("WorkflowItemId")]
        public virtual WorkflowItem WorkflowItem { get; set; }
    }
}
