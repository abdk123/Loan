using LMS.Crud.Dto;
using LMS.Crud.Interfaces;

namespace LMS.Loan.Indexes.Shared.Dto
{
    public class ReadIndexDto: ReadGrudDto
    {
        //public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }
}
