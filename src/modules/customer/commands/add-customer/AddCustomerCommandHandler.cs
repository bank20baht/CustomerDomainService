using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, string>
{
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<string> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        var newCustomer = await _customerRepository.AddCustomer(entity, cancellationToken);
        return $"Create Customer id {newCustomer} successful";
    }
}