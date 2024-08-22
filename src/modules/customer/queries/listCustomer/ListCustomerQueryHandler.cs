

using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using MediatR;

public class ListCustomerQueryHandler : IRequestHandler<ListCustomerQuery, List<Customer>>
{
    private readonly ICustomerRepository _repository;

    public ListCustomerQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Customer>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.ListCustomer();
        return customer;
    }
}