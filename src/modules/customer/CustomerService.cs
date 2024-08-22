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

}