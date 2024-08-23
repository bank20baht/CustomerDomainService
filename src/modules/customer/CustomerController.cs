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
            try
            {
                var response = await mediator.Send(new ListCustomerQuery(), cancellationToken);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapGet("{id:Guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            try
            {
                var response = await mediator.Send(new GetCustomerQuery(id), cancellationToken);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapPost("", async (CustomerRequestBody customer, IMediator mediator, CancellationToken cancellationToken = default) =>
        {
            try
            {
                var response = await mediator.Send(new AddCustomerCommand(customer), cancellationToken);
                return Results.Json(response, statusCode: StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapPut("{id:Guid}", async (Guid id, CustomerRequestBody customer, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            try
            {
                var response = await mediator.Send(new UpdateCustomerCommand(id, customer), cancellationToken);

                return Results.Json(response, statusCode: StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapPatch("{id:Guid}", async (Guid id, CustomerRequestBodyUpdateMobileNumber mobileNumber, IMediator mediator, CancellationToken cancellationToken = default) =>
        {

            try
            {
                var response = await mediator.Send(new UpdateCustomerMobileNumberCommand(id, mobileNumber), cancellationToken);
                return Results.Json(response, statusCode: StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapDelete("{id:Guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken = default) =>
        {
            try
            {
                var response = await mediator.Send(new DeleteCustomerCommand(id), cancellationToken);
                return Results.Json(response, statusCode: StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });
    }
}