using CustomerDomainService.IRepository;
using CustomerDomainService.Models;
using MediatR;

public class UpdateCustomerMobileNumberCommandHandler : IRequestHandler<UpdateCustomerMobileNumberCommand, string>
{

    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerMobileNumberCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<string> Handle(UpdateCustomerMobileNumberCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        var updateMobileNumber = await _customerRepository.UpdateMobileCustomer(request.Id, entity);
        if (updateMobileNumber == null)
        {
            return "can not update mobile number";
        }
        return updateMobileNumber;
    }
}