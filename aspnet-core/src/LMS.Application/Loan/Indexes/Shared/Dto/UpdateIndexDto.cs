using Abp.Application.Services.Dto;

namespace LMS.Loan.Indexes.Dto
{
    public class UpdateIndexDto
    {
        public IndexDto Value { get; set; }
        public string Action { get; set; }
    }
}
