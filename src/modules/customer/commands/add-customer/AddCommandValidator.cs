
using System.Xml.Serialization;
using FluentValidation;
using Microsoft.OpenApi.Expressions;

public class AddCommandValidator : AbstractValidator<AddCustomerCommand>
{
    public AddCommandValidator()
    {
        RuleFor(x => x.Body.first_name).NotEmpty().WithMessage("first_name cannot be empty");
        RuleFor(x => x.Body.last_name).NotEmpty().WithMessage("last_name cannot be empty");
        RuleFor(x => x.Body.mobile_number).NotEmpty().WithMessage("mobile_number cannot be empty");
    }
}
