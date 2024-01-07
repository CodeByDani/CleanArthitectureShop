using FluentValidation;

namespace CleanArthitecture.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(customer => customer.FirstName).NotEmpty()
            .WithMessage("First Name Can Not Be Empty !");
        RuleFor(customer => customer.LastName).NotEmpty()
            .WithMessage("Last Name Can Not Be Empty !"); ;
        RuleFor(customer => customer.Email).EmailAddress()
            .WithMessage("Email Format Is Not Valid !");

    }
}
