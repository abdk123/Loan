namespace LMS.Loan.Indexes.Dto
{
    public class CreateIndexDto
    {
        public IndexDto Value { get; set; }
        public string Action { get; set; }
    }

    public class CreateCountryDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
