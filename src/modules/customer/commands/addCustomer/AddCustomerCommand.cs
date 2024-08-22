

using CustomerDomainService.Dto;
using MediatR;

public record AddCustomerCommand(CustomerRequestBody body) : IRequest<string>;