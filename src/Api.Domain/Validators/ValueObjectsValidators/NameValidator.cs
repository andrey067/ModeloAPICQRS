using FluentValidation;
using Api.Domain.Entities.ValueObject;

namespace Api.Domain.Validators.ValueObjectsValidators
{
    public sealed class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome primeiro deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome primeiro deve ter no máximo 80 caracteres.");

            RuleFor(x => x.LastName)
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
