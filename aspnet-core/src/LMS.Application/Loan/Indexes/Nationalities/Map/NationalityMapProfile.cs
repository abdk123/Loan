using AutoMapper;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;

namespace LMS.Loan.Indexes.Nationalities.Map
{
    public class NationalityMapProfile : Profile
    {
        public NationalityMapProfile()
        {
            CreateMap<Nationality, IndexDto>();
            CreateMap<Nationality, ReadIndexDto>();
            CreateMap<IndexDto, Nationality>();
            CreateMap<CreateIndexDto, Nationality>();
            CreateMap<UpdateIndexDto, Nationality>();
        }
    }
}
