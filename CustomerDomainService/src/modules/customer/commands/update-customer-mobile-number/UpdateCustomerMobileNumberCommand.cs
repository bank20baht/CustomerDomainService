using CustomerDomainService.Dto;
using MediatR;

public record UpdateCustomerMobileNumberCommand(Guid Id, CustomerRequestBodyUpdateMobileNumber Body) : IRequest<string>;