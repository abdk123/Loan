using System.Collections;

namespace LMS.Crud.Dto
{
    public class ReadGrudDto
    {
        public int count { get; set; }
        public IEnumerable result { get; set; }
    }
}
