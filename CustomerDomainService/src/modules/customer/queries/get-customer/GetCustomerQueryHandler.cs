using CustomerDomainService.ApplicationErrors;
using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using MediatR;

public class GetCustomerQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerQuery, Customer?>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomer(request.Id, cancellationToken);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {request.Id} not found.");
        }
        return customer;
    }
}