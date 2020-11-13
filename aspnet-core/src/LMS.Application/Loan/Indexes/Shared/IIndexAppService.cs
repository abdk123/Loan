using LMS.Loan.Indexes.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes
{
    public interface IIndexAppService
    {
        Task<IList<IndexDto>> GetAllAsync();
        Task<IndexDto> GetById(int id);
        Task<IndexDto> CreateAsync(CreateIndexDto input);
        Task<IndexDto> UpdateAsync(UpdateIndexDto input);
        Task DeleteAsync(int id);
    }
}
