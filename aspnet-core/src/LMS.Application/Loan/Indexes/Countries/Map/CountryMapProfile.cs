using AutoMapper;
using LMS.Loan.Indexes.Dto;

namespace LMS.Loan.Indexes.Countries.Map
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<Country, IndexDto>();
            CreateMap<CreateIndexDto, Country>();
            CreateMap<UpdateIndexDto, Country>();
        }
    }
}
