

using CustomerDomainService.Dto;
using MediatR;

public record AddCustomerCommand(CustomerRequestBody Body) : IRequest<string>;