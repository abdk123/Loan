using Abp;
using Abp.Domain.Repositories;
using Abp.UI;
using LMS.Crud.Dto;
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

        [HttpPost]
        public async Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = await _repository.GetAllListAsync();
            IEnumerable<ReadIndexDto> nationalities = ObjectMapper.Map<List<ReadIndexDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                nationalities = operations.PerformFiltering(nationalities, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                nationalities = operations.PerformSorting(nationalities, dm.Sorted);
            }

            var count = nationalities.Count();

            if (dm.Skip != 0)
            {
                nationalities = operations.PerformSkip(nationalities, dm.Skip);
            }

            if (dm.Take != 0)
            {
                nationalities = operations.PerformTake(nationalities, dm.Take);
            }

            return new ReadGrudDto() { result = nationalities, count = count };
        }

        public async Task<UpdateIndexDto> GetForEdit(int id)
        {
            var nationality = await _repository.GetAsync(id);
            return ObjectMapper.Map<UpdateIndexDto>(nationality);
        }

        public async Task<IndexDto> GetById(int id)
        {
            var nationality = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(nationality);
        }

        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            var nationality = ObjectMapper.Map<Nationality>(input);

            await _repository.InsertAndGetIdAsync(nationality);

            return ObjectMapper.Map<IndexDto>(nationality);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            CheckBeforeUpdate(input);
            var nationality = await _repository.GetAsync(input.Id);
            ObjectMapper.Map<UpdateIndexDto, Nationality>(input, nationality);

            var updatedNationality = await _repository.UpdateAsync(nationality);

            return ObjectMapper.Map<IndexDto>(updatedNationality);
        }
        public async Task DeleteAsync(int id)
        {
            var nationality = await _repository.GetAsync(id);
            await _repository.DeleteAsync(nationality);
        }

        #region Helper methods
        private void CheckBeforeCreate(CreateIndexDto input)
        {
            var validationResultMessage = string.Empty;

            if (_repository.FirstOrDefault(x => x.Name == input.Name) != null)
            {
                validationResultMessage = $"{L(ValidationResultMessage.NameAleadyExist)} \n";
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        private void CheckBeforeUpdate(UpdateIndexDto input)
        {
            var validationResultMessage = string.Empty;

            if (_repository.FirstOrDefault(x => x.Name == input.Name && x.Id != input.Id) != null)
            {
                validationResultMessage = $"{L(ValidationResultMessage.NameAleadyExist)} \n";
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        #endregion
    }
}
