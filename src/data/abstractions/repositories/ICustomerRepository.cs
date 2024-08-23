using CustomerDomainService.Entity;

namespace CustomerDomainService.IRepository;
public interface ICustomerRepository
{
    Task<List<Customer>> ListCustomer(CancellationToken cancellationToken);
    Task<Customer?> GetCustomer(Guid id, CancellationToken cancellationToken);
    Task<string> AddCustomer(Customer customer, CancellationToken cancellationToken);
    Task<string?> UpdateCustomer(Guid id, Customer customer, CancellationToken cancellationToken);
    Task<string?> UpdateMobileCustomer(Guid id, Customer customerMobile, CancellationToken cancellationToken);
    Task<string?> DeleteCustomer(Guid id, CancellationToken cancellationToken);
}