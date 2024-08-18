
using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<string?> AddCustomer()
    {
        throw new NotImplementedException();
    }

    public Task<string?> DeleteCustomer()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer?> GetCustomer(Guid id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<List<Customer>> ListCustomer()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public Task<string?> UpdateCustomer()
    {
        throw new NotImplementedException();
    }

    public Task<string?> UpdateMobileCustomer()
    {
        throw new NotImplementedException();
    }
}