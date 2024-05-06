using FluentValidation;

namespace UserManager.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCmd>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("El Nombre no puede ser nulo.")
            .NotEmpty().WithMessage("El Nombre no puede ser vacio.");

        RuleFor(x => x.LastName)
            .NotNull().WithMessage("El Apellido no puede ser nulo.")
            .NotEmpty().WithMessage("El Apellido e no puede ser vacio.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("El correo no tiene el formato correcto");
    }
}