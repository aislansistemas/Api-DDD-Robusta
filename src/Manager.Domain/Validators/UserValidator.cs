using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(u => u.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no minimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(u => u.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")
                
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .MinimumLength(10)
                .WithMessage("O email deve ter no minimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(u => u.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no minimo 6 caracteres.")

                .MaximumLength(30)
                .WithMessage("A senha deve ter no máximo 30 caracteres.");
        }
    }
}