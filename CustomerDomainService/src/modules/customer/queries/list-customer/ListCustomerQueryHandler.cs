using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using MediatR;

public class ListCustomerQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<ListCustomerQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<List<Customer>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.ListCustomer(cancellationToken);
        return customer;
    }
}