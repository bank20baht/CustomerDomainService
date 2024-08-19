namespace CustomerDomainService.Utils;
public static class HttpError
{
    public static IResult InternalServerError()
    {
        return Results.Problem(statusCode: StatusCodes.Status500InternalServerError);
    }

    public static IResult NotFoundError()
    {
        return Results.Problem(statusCode: StatusCodes.Status404NotFound);
    }

    public static IResult BadRequestError()
    {
        return Results.Problem(statusCode: StatusCodes.Status400BadRequest);
    }

    public static IResult UnauthorizedError()
    {
        return Results.Problem(statusCode: StatusCodes.Status401Unauthorized);
    }

    public static IResult ForbiddenError()
    {
        return Results.Problem(statusCode: StatusCodes.Status403Forbidden);
    }

    public static IResult PaymentError()
    {
        return Results.Problem(statusCode: StatusCodes.Status402PaymentRequired);
    }

    public static IResult NotAcceptableError()
    {
        return Results.Problem(statusCode: StatusCodes.Status406NotAcceptable);
    }

    public static IResult ConflictError()
    {
        return Results.Problem(statusCode: StatusCodes.Status409Conflict);
    }

    public static IResult GoneError()
    {
        return Results.Problem(statusCode: StatusCodes.Status410Gone);
    }

    public static IResult LimitExceededError()
    {
        return Results.Problem(statusCode: StatusCodes.Status413PayloadTooLarge);
    }

    public static IResult TooManyRequestsError()
    {
        return Results.Problem(statusCode: StatusCodes.Status429TooManyRequests);
    }

}