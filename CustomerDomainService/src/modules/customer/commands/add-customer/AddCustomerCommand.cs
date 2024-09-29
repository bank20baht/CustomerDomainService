using CustomerDomainService.Dto;
using MediatR;

public class AddCustomerCommand(CustomerRequestBody body) : IRequest<string>
{
    public CustomerRequestBody Body { get; set; } = body;
}