using CustomerDomainService.IRepository;
using MediatR;

public class deleteCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, string>
{

    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var deleteCustomer = await _customerRepository.DeleteCustomer(request.Id, cancellationToken);
        if (deleteCustomer == false)
        {
            return "can not delete customer";
        }
        return $"Delete Customer id {request.Id} successful";
    }
}