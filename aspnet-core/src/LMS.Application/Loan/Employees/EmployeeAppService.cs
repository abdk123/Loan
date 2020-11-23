using Abp;
using Abp.Domain.Repositories;
using LMS.Authorization.Users;
using LMS.Loan.Employees.Dto;
using LMS.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Loan.Employees
{
    public class EmployeeAppService : AbpServiceBase, IEmployeeAppService
    {
        private readonly IRepository<Employee> _repository;
        private readonly UserManager _userManager;
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

        public async Task<IList<ReadEmployeeDto>> GetAllForGridAsync()
        {
            var employees = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<ReadEmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _repository.GetAsync(id);
            return ObjectMapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            var employee = ObjectMapper.Map<Employee>(input.Value);

            await _repository.InsertAndGetIdAsync(employee);

            //Create User
            var user = new User()
            {
                EmailAddress = input.Value.EmailAddress,
                Name = input.Value.Name,
                UserName = input.Value.EmailAddress.Split('@')[0],
                Surname = string.Empty,
                Password = "123456"
            };
            var identityResult = await _userManager.CreateAsync(user, user.Password);

            return ObjectMapper.Map<EmployeeDto>(employee);
        }
        public async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input)
        {
            var employee = await _repository.GetAsync(input.Value.Id);
            ObjectMapper.Map<EmployeeDto, Employee>(input.Value, employee);

            var updatedEmployee = await _repository.UpdateAsync(employee);

            return ObjectMapper.Map<EmployeeDto>(updatedEmployee);
        }
        public async Task DeleteAsync(int id)
        {
            var employee = await _repository.GetAsync(id);
            await _repository.DeleteAsync(employee);
        }

        
    }
}
