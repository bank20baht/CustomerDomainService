using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerDomainService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddCustomer(Customer customer, CancellationToken cancellationToken)
        {
            var entry = await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return $"Create {entry.Entity.id} successful";
        }

        public async Task<string?> DeleteCustomer(Guid id, CancellationToken cancellationToken)
        {
            var customerToRemove = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (customerToRemove == null)
            {
                return null;
            }
            _dbContext.Customers.Remove(customerToRemove);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return $"Delete {customerToRemove.id} successful";
        }

        public async Task<Customer?> GetCustomer(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id, cancellationToken);
        }

        public async Task<List<Customer>> ListCustomer(CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<string?> UpdateCustomer(Guid id, Customer customer, CancellationToken cancellationToken)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.first_name = customer.first_name;
            existingCustomer.last_name = customer.last_name;
            existingCustomer.address = customer.address;
            existingCustomer.mobile_number = customer.mobile_number;

            _dbContext.Entry(existingCustomer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return $"Update {existingCustomer.id} successful";
        }

        public async Task<string?> UpdateMobileCustomer(Guid id, Customer customerMobile, CancellationToken cancellationToken)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.mobile_number = customerMobile.mobile_number;

            _dbContext.Entry(existingCustomer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return $"Update {existingCustomer.id} successful";
        }
    }
}
