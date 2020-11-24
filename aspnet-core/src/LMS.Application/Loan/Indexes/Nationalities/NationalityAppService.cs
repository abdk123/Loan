using Abp;
using Abp.Domain.Repositories;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes.Nationalities
{
    public class NationalityAppService : AbpServiceBase, INationalityAppService
    { 
        private readonly IRepository<Nationality> _repository;
        public NationalityAppService(IRepository<Nationality> repository)
        {
            _repository = repository;
        }
        public async Task<IList<IndexDto>> GetAllAsync()
        {
            var nationalities = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<IndexDto>>(nationalities);
        }

        public async Task<IList<ReadIndexDto>> GetAllForGridAsync()
        {
            var nationalities = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<ReadIndexDto>>(nationalities);
        }

        public async Task<IndexDto> GetById(int id)
        {
            var nationality = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(nationality);
        }

        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            var nationality = ObjectMapper.Map<Nationality>(input.Value);

            await _repository.InsertAndGetIdAsync(nationality);

            return ObjectMapper.Map<IndexDto>(nationality);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            var nationality = await _repository.GetAsync(input.Value.Id);
            ObjectMapper.Map<IndexDto, Nationality>(input.Value, nationality);

            var updatedNationality = await _repository.UpdateAsync(nationality);

            return ObjectMapper.Map<IndexDto>(updatedNationality);
        }
        public async Task DeleteAsync(int id)
        {
            var nationality = await _repository.GetAsync(id);
            await _repository.DeleteAsync(nationality);
        }

        
    }
}
