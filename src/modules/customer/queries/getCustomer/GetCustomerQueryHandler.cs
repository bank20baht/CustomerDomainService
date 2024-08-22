using CustomerDomainService.Entity;
using CustomerDomainService.IRepository;
using MediatR;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomer(request.Id);
        return customer;
    }
}