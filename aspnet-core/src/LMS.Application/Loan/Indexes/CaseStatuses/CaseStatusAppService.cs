using Abp.Domain.Repositories;
using Abp.UI;
using LMS.Crud.Dto;
using LMS.Loan.Indexes.Dto;
using LMS.Loan.Indexes.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Loan.Indexes.CaseStatuses
{
    public class CaseStatusAppService : LMSAppServiceBase, ICaseStatusAppService
    {
        private readonly IRepository<CaseStatus> _repository;
        public CaseStatusAppService(IRepository<CaseStatus> repository)
        {
            _repository = repository;
        }
        public async Task<IList<IndexDto>> GetAllAsync()
        {
            var allStatus = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<IndexDto>>(allStatus);
        }
        [HttpPost]
        public async Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = await _repository.GetAllListAsync();
            IEnumerable<ReadIndexDto> allStatus = ObjectMapper.Map<List<ReadIndexDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                allStatus = operations.PerformFiltering(allStatus, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                allStatus = operations.PerformSorting(allStatus, dm.Sorted);
            }

            IEnumerable groupDs = new List<ReadIndexDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformSelect(allStatus, dm.Group);
            }

            var count = allStatus.Count();

            if (dm.Skip != 0)
            {
                allStatus = operations.PerformSkip(allStatus, dm.Skip);
            }

            if (dm.Take != 0)
            {
                allStatus = operations.PerformTake(allStatus, dm.Take);
            }

            return new ReadGrudDto() { result = allStatus, count = count, groupDs = groupDs };
        }
        public async Task<IndexDto> GetById(int id)
        {
            var status = await _repository.GetAsync(id);
            return ObjectMapper.Map<IndexDto>(status);
        }
        public async Task<UpdateIndexDto> GetForEdit(int id)
        {
            var status = await _repository.GetAsync(id);
            return ObjectMapper.Map<UpdateIndexDto>(status);
        }
        public async Task<IndexDto> CreateAsync(CreateIndexDto input)
        {
            CheckBeforeCreate(input);

            var status = ObjectMapper.Map<CaseStatus>(input);

            await _repository.InsertAndGetIdAsync(status);

            return ObjectMapper.Map<IndexDto>(status);
        }
        public async Task<IndexDto> UpdateAsync(UpdateIndexDto input)
        {
            CheckBeforeUpdate(input);

            var status = await _repository.GetAsync(input.Id);

            ObjectMapper.Map<UpdateIndexDto, CaseStatus>(input, status);

            var updatedCaseStatus = await _repository.UpdateAsync(status);

            return ObjectMapper.Map<IndexDto>(updatedCaseStatus);
        }
        public async Task DeleteAsync(int id)
        {
            var status = await _repository.GetAsync(id);
            await _repository.DeleteAsync(status);
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