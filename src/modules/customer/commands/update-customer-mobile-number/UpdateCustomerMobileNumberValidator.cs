using FluentValidation;

public class UpdateCustomerMobileNumberValidator : AbstractValidator<UpdateCustomerMobileNumberCommand>
{
    public UpdateCustomerMobileNumberValidator()
    {
        RuleFor(x => x.Body.mobile_number).NotEmpty().WithMessage("mobile_number cannot be empty");
    }
}