using FluentValidation;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Body.first_name).NotEmpty().WithMessage("first_name cannot be empty");
        RuleFor(x => x.Body.last_name).NotEmpty().WithMessage("last_name cannot be empty");
        RuleFor(x => x.Body.address).NotEmpty().WithMessage("address cannot be empty");
        RuleFor(x => x.Body.mobile_number).NotEmpty().WithMessage("mobile_number cannot be empty");
    }
}