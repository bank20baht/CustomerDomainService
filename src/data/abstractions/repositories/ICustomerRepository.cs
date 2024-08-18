using CustomerDomainService.Entity;

namespace CustomerDomainService.IRepository;
public interface ICustomerRepository
{
    Task<List<Customer>> ListCustomer();
    Task<Customer?> GetCustomer(Guid id);
    Task<string?> AddCustomer();
    Task<string?> UpdateCustomer();
    Task<string?> UpdateMobileCustomer();
    Task<string?> DeleteCustomer();
}