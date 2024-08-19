
using CustomerDomainService.Dto;
using CustomerDomainService.Entity;

namespace CustomerDomainService.Models;

public class CustomerModel
{
    public Guid id { get; set; }
    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;
    public string address { get; set; } = null!;
    public string mobile_number { get; set; } = null!;
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public static Customer ToEntity(CustomerRequestBody customer)
    {
        return new Customer
        {
            first_name = customer.first_name,
            last_name = customer.last_name,
            address = customer.address,
            mobile_number = customer.mobile_number
        };
    }

    public static Customer ToEntity(TodoRequestBodyUpdateMobileNumber customer)
    {
        return new Customer
        {
            mobile_number = customer.mobile_number,
        };
    }
}