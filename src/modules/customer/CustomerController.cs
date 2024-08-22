
using CustomerDomainService.Dto;
using CustomerDomainService.Utils;
using MediatR;
namespace CustomerDomainService.Controller;

public static class CustomerController
{
    public static void UseCustomerController(this IEndpointRouteBuilder routes)
    {
        var customerRoutes = routes.MapGroup("/customer");

        customerRoutes.MapGet("", async (IMediator mediator) =>
        {
            try
            {
                var response = await mediator.Send(new ListCustomerQuery());
                return Results.Ok(response);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        customerRoutes.MapGet("{id:Guid}", async (Guid id, IMediator mediator) =>
        {

            try
            {
                var response = await mediator.Send(new GetCustomerQuery(id));
                return Results.Ok(response);
            }
            catch (Exception ex)
            {

                return HttpError.InternalServerError();
            }
        });

        // customerRoutes.MapPost("", async (CustomerRequestBody customer, IMediator mediator) =>
        // {
        //     try
        //     {
        //         var response = await customerService.CreateConsumer(customer);
        //         return Results.Json(response, statusCode: StatusCodes.Status201Created);
        //     }
        //     catch (Exception ex)
        //     {

        //         return HttpError.InternalServerError();
        //     }
        // });

        // customerRoutes.MapPut("{id:Guid}", async (Guid id, CustomerRequestBody customer, IMediator mediator) =>
        // {

        //     try
        //     {
        //         var response = await customerService.UpdateCustomerAsync(id, customer);

        //         return Results.Json(response, statusCode: StatusCodes.Status200OK);
        //     }
        //     catch (Exception ex)
        //     {

        //         return HttpError.InternalServerError();
        //     }
        // });

        // customerRoutes.MapPatch("{id:Guid}", async (Guid id, CustomerRequestBodyUpdateMobileNumber mobileNumber, IMediator mediator) =>
        // {

        //     try
        //     {
        //         var response = await customerService.UpdateCustomerMobileNumberAsync(id, mobileNumber);
        //         return Results.Json(response, statusCode: StatusCodes.Status200OK);
        //     }
        //     catch (Exception ex)
        //     {

        //         return HttpError.InternalServerError();
        //     }
        // });

        // customerRoutes.MapDelete("{id:Guid}", async (Guid id, IMediator mediator) =>
        // {
        //     try
        //     {
        //         var response = await customerService.DeleteCustomer(id);
        //         return Results.Json(response, statusCode: StatusCodes.Status200OK);
        //     }
        //     catch (Exception ex)
        //     {

        //         return HttpError.InternalServerError();
        //     }
        // });
    }
}