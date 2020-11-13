using Abp.Application.Services.Dto;

namespace LMS.Loan.Indexes.Dto
{
    public class IndexDto: FullAuditedEntityDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
