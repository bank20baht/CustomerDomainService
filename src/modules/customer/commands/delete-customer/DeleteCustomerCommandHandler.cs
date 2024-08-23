using CustomerDomainService.IRepository;
using MediatR;

public class deleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
{

    private readonly ICustomerRepository _customerRepository;

    public deleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var deleteCustomer = await _customerRepository.DeleteCustomer(request.Id, cancellationToken);
        if (deleteCustomer == null)
        {
            return "can not delete customer";
        }
        return deleteCustomer;
    }
}