

using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, string>
{
    private readonly ICustomerRepository _repository;

    public AddCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.body);
        var newCustomer = await _repository.AddCustomer(entity);
        return newCustomer;
    }
}