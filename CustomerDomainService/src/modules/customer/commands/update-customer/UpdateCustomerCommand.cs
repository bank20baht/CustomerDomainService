using CustomerDomainService.Dto;
using MediatR;

public record UpdateCustomerCommand(Guid Id, CustomerRequestBody Body) : IRequest<string>;