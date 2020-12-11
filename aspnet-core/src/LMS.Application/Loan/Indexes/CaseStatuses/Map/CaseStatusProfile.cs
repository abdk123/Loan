using AutoMapper;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;

namespace LMS.Loan.Indexes.CaseStatuses.Map
{
    public class CaseStatusProfile : Profile
    {
        public CaseStatusProfile()
        {
            CreateMap<CaseStatus, IndexDto>();
            CreateMap<CaseStatus, ReadIndexDto>();
            CreateMap<CaseStatus, UpdateIndexDto>();
            CreateMap<IndexDto, CaseStatus>();
            CreateMap<CreateIndexDto, CaseStatus>();
            CreateMap<UpdateIndexDto, CaseStatus>();
        }
    }
}
