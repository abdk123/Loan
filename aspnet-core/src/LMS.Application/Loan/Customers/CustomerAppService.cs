using Abp;
using Abp.Domain.Repositories;
using LMS.Authorization.Users;
using LMS.Loan.Customers.Dto;
using LMS.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Loan.Customers
{
    public class CustomerAppService : AbpServiceBase, ICustomerAppService
    {
        private readonly IRepository<Customer> _repository;
        private readonly UserManager _userManager;
        public CustomerAppService(IRepository<Customer> repository, UserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task<IList<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<IList<ReadCustomerDto>> GetAllForGridAsync()
        {
            var customers = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<ReadCustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetById(int id)
        {
            var customer = await _repository.GetAsync(id);
            return ObjectMapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto input)
        {
            var customer = ObjectMapper.Map<Customer>(input.Value);

            await _repository.InsertAndGetIdAsync(customer);

            return ObjectMapper.Map<CustomerDto>(customer);
        }
        public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto input)
        {
            var customer = await _repository.GetAsync(input.Value.Id);
            ObjectMapper.Map<CustomerDto, Customer>(input.Value, customer);

            var updatedCustomer = await _repository.UpdateAsync(customer);

            return ObjectMapper.Map<CustomerDto>(updatedCustomer);
        }
        public async Task DeleteAsync(int id)
        {
            var customer = await _repository.GetAsync(id);
            await _repository.DeleteAsync(customer);
        }

        
    }
}
