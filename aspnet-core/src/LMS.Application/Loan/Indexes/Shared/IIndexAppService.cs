using Abp.Application.Services;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes
{
    public interface IIndexAppService : IApplicationService
    {
        Task<IList<IndexDto>> GetAllAsync();
        Task<IList<ReadIndexDto>> GetAllForGridAsync();
        Task<IndexDto> GetById(int id);
        Task<IndexDto> CreateAsync(CreateIndexDto input);
        Task<IndexDto> UpdateAsync(UpdateIndexDto input);
        Task DeleteAsync(int id);
        
    }
}
