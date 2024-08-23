using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
{

    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        var updateCustomer = await _customerRepository.UpdateCustomer(request.Id, entity, cancellationToken);
        if (updateCustomer == null)
        {
            return "can not update";
        }
        return updateCustomer;
    }
}