using Abp;
using Abp.Domain.Repositories;
using LMS.Loan.Indexes.Dto;
using System.Collections.Generic;
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

        public async Task<IndexDto> GetById(int id)
        {
            var country = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(country);
        }

        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            var country = ObjectMapper.Map<Country>(input);

            var addedCountry = await _repository.InsertAsync(country);

            return ObjectMapper.Map<IndexDto>(addedCountry);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            var country = await _repository.GetAsync(input.Id);
            ObjectMapper.Map<UpdateIndexDto, Country>(input, country);

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
