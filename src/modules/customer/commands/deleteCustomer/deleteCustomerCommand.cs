using MediatR;

public record DeleteCustomerCommand(Guid Id) : IRequest<string>;
