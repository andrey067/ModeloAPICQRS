using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Validators
{
    public class UserValidators : AbstractValidator<User>
    {
        public UserValidators()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name.FirstName)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome primeiro deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome primeiro deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Name.LastName)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O segundo nome  deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O  segundo nome deve ter no máximo 80 caracteres.");
        }
    }
}
