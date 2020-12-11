using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Users;
using LMS.Loan.Cases;
using LMS.Loan.Customers;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Workflows
{
    public class WorkflowItem : FullAuditedEntity
    {
        public WorkflowItem()
        {
            WorkflowSteps = new List<WorkflowStep>();
        }
        public Case Case { get; set; }
        public virtual IList<WorkflowStep> WorkflowSteps { get; set; }
        public int WorkflowSettingId { get; set; }
        [ForeignKey("WorkflowSettingId")]
        public WorkflowSetting WorkflowSetting { get; set; }

    }
}
