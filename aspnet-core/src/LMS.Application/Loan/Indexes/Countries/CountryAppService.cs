using Abp;
using Abp.Domain.Repositories;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes.Countries
{
    public class CountryAppService : AbpServiceBase, ICountryAppService
    {
        private readonly IRepository<Country> _repository;
        public CountryAppService(IRepository<Country> repository)
        {
            _repository = repository;
        }
        public async Task<IList<IndexDto>> GetAllAsync()
        {
            var countries = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<IndexDto>>(countries);
        }

        public async Task<IList<ReadIndexDto>> GetAllForGridAsync()
        {
            var countries = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<ReadIndexDto>>(countries);
        }

        public async Task<IndexDto> GetById(int id)
        {
            var country = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(country);
        }

        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            var country = ObjectMapper.Map<Country>(input.Value);

            await _repository.InsertAndGetIdAsync(country);

            return ObjectMapper.Map<IndexDto>(country);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            var country = await _repository.GetAsync(input.Value.Id);
            ObjectMapper.Map<IndexDto, Country>(input.Value, country);

            var updatedCountry = await _repository.UpdateAsync(country);

            return ObjectMapper.Map<IndexDto>(updatedCountry);
        }
        public async Task DeleteAsync(int id)
        {
            var country = await _repository.GetAsync(id);
            await _repository.DeleteAsync(country);
        }

        
    }
}
