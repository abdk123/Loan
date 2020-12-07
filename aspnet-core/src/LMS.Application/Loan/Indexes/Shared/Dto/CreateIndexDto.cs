using Abp.Application.Services.Dto;

namespace LMS.Loan.Indexes.Dto
{
    public class CreateIndexDto:EntityDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }

}
