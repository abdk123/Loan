using Abp.Application.Services;
using LMS.Crud.Dto;
using LMS.Loan.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes
{
    public interface IIndexAppService : IApplicationService
    {
        Task<IList<IndexDto>> GetAllAsync();
        Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm);
        Task<IndexDto> GetById(int id);
        Task<UpdateIndexDto> GetForEdit(int id);
        Task<IndexDto> CreateAsync(CreateIndexDto input);
        Task<IndexDto> UpdateAsync(UpdateIndexDto input);
        Task DeleteAsync(int id);
        
    }
}
