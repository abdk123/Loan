using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Users;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Workflows
{
    public class WorkflowApproval : FullAuditedEntity
    {
        public WorkflowApproval()
        {
        }

        public bool IsManager { get; set; }
        public int Order { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int WorkflowSettingId { get; set; }
        [ForeignKey("WorkflowSettingId")]
        public virtual WorkflowSetting WorkflowSetting { get; set; }
        


    }
}
