using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using LMS.Authorization.Users;
using LMS.Crud.Dto;
using LMS.Loan.Employees.Dto;
using LMS.Users;
using LMS.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Loan.Employees
{
    public class EmployeeAppService : AbpServiceBase, IEmployeeAppService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IAbpSession _abpSession;
        private readonly UserManager _userManager;

        public EmployeeAppService(
            IRepository<Employee> repository,
            UserManager userManager, 
            IAbpSession abpSession)
        {
            _repository = repository;
            _userManager = userManager;
            _abpSession = abpSession;
        }
        public EmployeeAppService(IRepository<Employee> repository, UserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task<IList<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<EmployeeDto>>(employees);
        }
        public async Task<IList<EmployeeForDropdownDto>> GetForDropdown()
        {
            var employees = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<EmployeeForDropdownDto>>(employees);
        }
        [HttpPost]
        public async Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = await _repository.GetAllListAsync();
            IEnumerable<ReadEmployeeDto> employees = ObjectMapper.Map<List<ReadEmployeeDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                employees = operations.PerformFiltering(employees, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                employees = operations.PerformSorting(employees, dm.Sorted);
            }

            var count = employees.Count();

            if (dm.Skip != 0)
            {
                employees = operations.PerformSkip(employees, dm.Skip);
            }

            if (dm.Take != 0)
            {
                employees = operations.PerformTake(employees, dm.Take);
            }
            
            return new ReadGrudDto() { result = employees, count = count };
        }
        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _repository.GetAsync(id);
            return ObjectMapper.Map<EmployeeDto>(employee);
        }
        public async Task<UpdateEmployeeDto> GetForEdit(int id)
        {
            var employee = await _repository.GetAsync(id);
            return ObjectMapper.Map<UpdateEmployeeDto>(employee);
        }
        [UnitOfWork]
        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            CheckBeforeCreate(input);
            var employee = ObjectMapper.Map<Employee>(input);

            //Create User
            var user = await CreateAccountForEmployeeAsync(input);

            employee.UserId = user.Id;
            await _repository.InsertAsync(employee);

            return ObjectMapper.Map<EmployeeDto>(employee);
        }
        public async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input)
        {
            var employee = await _repository.GetAsync(input.Id);
            ObjectMapper.Map<UpdateEmployeeDto, Employee>(input, employee);

            var updatedEmployee = await _repository.UpdateAsync(employee);

            return ObjectMapper.Map<EmployeeDto>(updatedEmployee);
        }
        public async Task DeleteAsync(int id)
        {
            var employee = await _repository.GetAsync(id);
            await _repository.DeleteAsync(employee);
        }
        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        private void CheckBeforeCreate(CreateEmployeeDto input)
        {
            var validationResultMessage = string.Empty;

            if (_repository.FirstOrDefault(x => x.Name == input.Name) != null)
            {
                validationResultMessage = L($"{ValidationResultMessage.EmployeeNameAleadyExist} \n");
            }
            if (_repository.FirstOrDefault(x => x.EmailAddress == input.EmailAddress) != null)
            {
                validationResultMessage += L(ValidationResultMessage.EmailAddressAleadyExist);
            }
            if(!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        private async Task<User> CreateAccountForEmployeeAsync(CreateEmployeeDto input)
        {
            var user = new User()
            {
                EmailAddress = input.EmailAddress,
                Name = input.Name,
                UserName = input.EmailAddress.Split('@')[0],
                Surname = string.Empty,
                Password = "A@123qwe",
                IsActive = true
            };

            user.IsEmailConfirmed = false;

            CheckErrors(await _userManager.CreateAsync(user, "A@123qwe"));

            //Add roles to user

            return user;
        }

        
    }
}
