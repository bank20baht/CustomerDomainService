using CustomerDomainService.Entity;

namespace CustomerDomainService.IRepository;
public interface ICustomerRepository
{
    Task<List<Customer>> ListCustomer(CancellationToken cancellationToken);
    Task<Customer?> GetCustomer(Guid id, CancellationToken cancellationToken);
    Task<Guid> AddCustomer(Customer customer, CancellationToken cancellationToken);
    Task<bool> UpdateCustomer(Guid id, Customer customer, CancellationToken cancellationToken);
    Task<bool> UpdateMobileCustomer(Guid id, Customer customerMobile, CancellationToken cancellationToken);
    Task<bool> DeleteCustomer(Guid id, CancellationToken cancellationToken);
}