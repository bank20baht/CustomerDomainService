using CustomerDomainService.Entity;
using MediatR;

public record GetCustomerQuery(Guid Id) : IRequest<Customer?>;
