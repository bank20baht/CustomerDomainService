

using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using MediatR;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer?>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetCustomer(request.Id);
        return customer;
    }
}