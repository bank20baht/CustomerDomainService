using CustomerDomainService.Dto;
using MediatR;

public class AddCustomerCommand : IRequest<string>
{
    public CustomerRequestBody Body { get; set; }

    public AddCustomerCommand(CustomerRequestBody body)
    {
        Body = body;
    }
}