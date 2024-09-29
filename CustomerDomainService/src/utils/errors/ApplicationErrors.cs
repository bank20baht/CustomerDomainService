namespace CustomerDomainService.ApplicationErrors
{
    public class NotFoundException(string message) : Exception(message)
    {
    }

}

