
namespace CustomerDomainService.Dto;

public class CustomerRequestBody
{

    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;
    public string address { get; set; } = null!;
    public string mobile_number { get; set; } = null!;
}

public class TodoRequestBodyUpdateMobileNumber
{
    public string mobile_number { get; set; } = null!;
}