using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerDomainService.Repository
{
    public class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Guid> AddCustomer(Customer customer, CancellationToken cancellationToken)
        {
            var entry = await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entry.Entity.id;
        }

        public async Task<bool> DeleteCustomer(Guid id, CancellationToken cancellationToken)
        {
            var customerToRemove = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (customerToRemove == null)
            {
                return false;
            }

            _dbContext.Customers.Remove(customerToRemove);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Customer?> GetCustomer(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id, cancellationToken);
        }

        public async Task<List<Customer>> ListCustomer(CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateCustomer(Guid id, Customer customer, CancellationToken cancellationToken)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return false;
            }

            existingCustomer.first_name = customer.first_name;
            existingCustomer.last_name = customer.last_name;
            existingCustomer.address = customer.address;
            existingCustomer.mobile_number = customer.mobile_number;

            _dbContext.Entry(existingCustomer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> UpdateMobileCustomer(Guid id, Customer customerMobile, CancellationToken cancellationToken)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return false;
            }

            existingCustomer.mobile_number = customerMobile.mobile_number;

            _dbContext.Entry(existingCustomer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
