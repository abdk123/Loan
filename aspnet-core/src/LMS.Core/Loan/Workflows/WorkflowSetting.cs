using Abp.Domain.Entities.Auditing;
using LMS.Loan.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Loan.Workflows
{
    public class WorkflowSetting : FullAuditedEntity
    {
        public WorkflowSetting()
        {
            WorkflowApprovals = new List<WorkflowApproval>();
        }

        [MaxLength(LMSConsts.MinStringLength)]
        public string Name { get; set; }

        [MaxLength(LMSConsts.MaxStringLength)]
        public string Note { get; set; }

        public int CaseStatusId { get; set; }
        [ForeignKey("CaseStatusId")]
        public virtual CaseStatus CaseStatus { get; set; }

        public virtual IList<WorkflowApproval> WorkflowApprovals { get; set; }


    }
}
