using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        //TODO - Acrecentar mais Validações de Dominio
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
        }
    }
}
