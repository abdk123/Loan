using Abp.Domain.Repositories;
using Abp.UI;
using LMS.Crud.Dto;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes.Countries
{
    public class CountryAppService : LMSAppServiceBase, ICountryAppService
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
        [HttpPost]
        public async Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = await _repository.GetAllListAsync();
            IEnumerable<ReadIndexDto> countries = ObjectMapper.Map<List<ReadIndexDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                countries = operations.PerformFiltering(countries, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                countries = operations.PerformSorting(countries, dm.Sorted);
            }

            IEnumerable groupDs = new List<ReadIndexDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformSelect(countries, dm.Group);
            }

            var count = countries.Count();

            if (dm.Skip != 0)
            {
                countries = operations.PerformSkip(countries, dm.Skip);
            }

            if (dm.Take != 0)
            {
                countries = operations.PerformTake(countries, dm.Take);
            }

            return new ReadGrudDto() { result = countries, count = count, groupDs = groupDs };
        }
        public async Task<IndexDto> GetById(int id)
        {
            var country = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(country);
        }
        public async Task<UpdateIndexDto> GetForEdit(int id)
        {
            var country = await _repository.GetAsync(id);
            return ObjectMapper.Map<UpdateIndexDto>(country);
        }
        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            CheckBeforeCreate(input);

            var country = ObjectMapper.Map<Country>(input);

            await _repository.InsertAndGetIdAsync(country);

            return ObjectMapper.Map<IndexDto>(country);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            CheckBeforeUpdate(input);

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

        #region Helper methods
        private void CheckBeforeCreate(CreateIndexDto input)
        {
            var validationResultMessage = string.Empty;

            if (_repository.FirstOrDefault(x => x.Name == input.Name) != null)
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }
            
            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        private void CheckBeforeUpdate(UpdateIndexDto input)
        {
            var validationResultMessage = string.Empty;

            if (_repository.FirstOrDefault(x => x.Name == input.Name && x.Id != input.Id) != null)
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        #endregion
    }
}
