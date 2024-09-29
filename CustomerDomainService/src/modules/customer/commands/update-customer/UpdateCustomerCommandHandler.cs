using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand, string>
{

    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        var updateCustomer = await _customerRepository.UpdateCustomer(request.Id, entity, cancellationToken);
        if (updateCustomer == false)
        {
            return "can not update";
        }
        return $"Update Customer id {request.Id} successful";
    }
}