using CustomerDomainService.Dto;
using CustomerDomainService.Utils;
using MediatR;
namespace CustomerDomainService.Controller;

public static class CustomerController
{
    public static void UseCustomerController(this IEndpointRouteBuilder routes, CancellationToken cancellationToken = default)
    {
        var customerRoutes = routes.MapGroup("/customer");

        customerRoutes.MapGet("", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new ListCustomerQuery(), cancellationToken);
            return Results.Ok(response);

        });

        customerRoutes.MapGet("{id:Guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken = default) =>
        {
            var response = await mediator.Send(new GetCustomerQuery(id), cancellationToken);
            if (response == null)
            {
                return Results.NotFound(new { error = $"Customer with ID {id} not found." });
            }
            return Results.Ok(response);
        });


        customerRoutes.MapPost("", async (CustomerRequestBody customer, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            var response = await mediator.Send(new AddCustomerCommand(customer), cancellationToken);
            return Results.Json(response, statusCode: StatusCodes.Status201Created);

        });

        customerRoutes.MapPut("{id:Guid}", async (Guid id, CustomerRequestBody customer, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            var response = await mediator.Send(new UpdateCustomerCommand(id, customer), cancellationToken);

            return Results.Json(response, statusCode: StatusCodes.Status200OK);

        });

        customerRoutes.MapPatch("{id:Guid}", async (Guid id, CustomerRequestBodyUpdateMobileNumber mobileNumber, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            var response = await mediator.Send(new UpdateCustomerMobileNumberCommand(id, mobileNumber), cancellationToken);
            return Results.Json(response, statusCode: StatusCodes.Status200OK);


        });

        customerRoutes.MapDelete("{id:Guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            var response = await mediator.Send(new DeleteCustomerCommand(id), cancellationToken);
            return Results.Json(response, statusCode: StatusCodes.Status200OK);

        });
    }
}