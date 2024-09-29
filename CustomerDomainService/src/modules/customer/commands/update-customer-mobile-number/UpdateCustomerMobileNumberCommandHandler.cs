using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class UpdateCustomerMobileNumberCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerMobileNumberCommand, string>
{

    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<string> Handle(UpdateCustomerMobileNumberCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        var updateMobileNumber = await _customerRepository.UpdateMobileCustomer(request.Id, entity, cancellationToken);
        if (updateMobileNumber == false)
        {
            return "can not update mobile number";
        }
        return $"Update Customer Mobile Number id {request.Id} successful";
    }
}