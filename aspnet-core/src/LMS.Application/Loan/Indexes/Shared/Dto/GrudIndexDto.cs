using LMS.Loan.Indexes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Loan.Indexes.Shared.Dto
{
    public class GrudIndexDto
    {
        public IndexDto Value { get; set; }
        public int Key { get; set; }
        public int RelationalKey { get; set; }
        public List<IndexDto> Deleted { get; set; }
    }
}
