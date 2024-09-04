using CustomerDomainService.Entity;
using MediatR;

public record ListCustomerQuery() : IRequest<List<Customer>>;