using CustomerDomainService.Dto;
using CustomerDomainService.Entity;
using CustomerDomainService.Models;
using CustomerDomainService.Repository;

namespace CustomerDomainService.Service;
public class CustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly CustomerRepository _customerRepository;

    public CustomerService(ILogger<CustomerService> logger, CustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> ListConsumerAsync()
    {
        var customers = await _customerRepository.ListCustomer();
        return customers;
    }

    public async Task<Customer?> GetCustomerAsync(Guid id)
    {
        var customer = await _customerRepository.GetCustomer(id);
        return customer;
    }

    public async Task<string> UpdateCustomerAsync(Guid id, CustomerRequestBody customer)
    {
        var entity = CustomerModel.ToEntity(customer);
        var updateCustomer = await _customerRepository.UpdateCustomer(id, entity);
        if (updateCustomer == null)
        {
            return "can not update";
        }
        return updateCustomer;
    }

    public async Task<string> UpdateCustomerMobileNumberAsync(Guid id, CustomerRequestBodyUpdateMobileNumber mobileNumber)
    {
        var entity = CustomerModel.ToEntity(mobileNumber);
        var updateMobileNumber = await _customerRepository.UpdateMobileCustomer(id, entity);
        if (updateMobileNumber == null)
        {
            return "can not update mobile number";
        }
        return updateMobileNumber;
    }

    public async Task<string> Create(CustomerRequestBody customer)
    {
        var entity = CustomerModel.ToEntity(customer);
        var newCustomer = await _customerRepository.AddCustomer(entity);
        return newCustomer;
    }

    public async Task<string> DeleteCustomer(Guid id)
    {
        var deleteCustomer = await _customerRepository.DeleteCustomer(id);
        if (deleteCustomer == null)
        {
            return "can not delete customer";
        }
        return deleteCustomer;
    }
}