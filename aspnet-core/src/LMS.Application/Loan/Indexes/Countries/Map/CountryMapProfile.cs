using AutoMapper;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;

namespace LMS.Loan.Indexes.Countries.Map
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<Country, IndexDto>();
            CreateMap<Country, ReadIndexDto>();
            CreateMap<Country, UpdateIndexDto>();
            CreateMap<IndexDto, Country>();
            CreateMap<CreateIndexDto, Country>();
            CreateMap<UpdateIndexDto, Country>();
        }
    }
}
