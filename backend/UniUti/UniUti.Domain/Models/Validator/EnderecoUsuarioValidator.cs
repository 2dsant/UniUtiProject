using FluentValidation;

namespace UniUti.Domain.Models.Validator
{
    public class EnderecoUsuarioValidator : AbstractValidator<EnderecoUsuario>
    {
        public EnderecoUsuarioValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")
                .NotNull()
                .WithMessage("A entidade não pode ser nula.");


            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Id não pode ser vazio.");

            RuleFor(x => x.ApplicationUserId)
                .NotNull()
                .WithMessage("ApplicationUserId não pode ser nulo.")
                .NotEmpty()
                .WithMessage("ApplicationUserId não pode ser vazio.");

            RuleFor(x => x.Cep)
                .NotNull()
                .WithMessage("O cep não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O cep não pode ser vazio.")
                .Length(8)
                .WithMessage("O cep deve ter 8 caracteres.");

            RuleFor(x => x.Rua)
                .NotNull()
                .WithMessage("A rua não pode ser nula.")
                .NotEmpty()
                .WithMessage("A rua não pode ser vazia.")
                .MaximumLength(100)
                .WithMessage("A rua deve ter no máximo 100 caracteres.")
                .MinimumLength(5)
                .WithMessage("A rua deve ter no mínimo 5 caracteres.");

            RuleFor(x => x.Cidade)
                .NotNull()
                .WithMessage("A cidade não pode ser nula.")
                .NotEmpty()
                .WithMessage("A cidade não pode ser vazia.")
                .MaximumLength(50)
                .WithMessage("A cidade deve ter no máximo 100 caracteres.")
                .MinimumLength(5)
                .WithMessage("A cidade deve ter no mínimo 5 caracteres.");

            RuleFor(x => x.Estado)
                .NotNull()
                .WithMessage("O estado não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O estado não pode ser vazia.")
                .Length(2)
                .WithMessage("O estado deve ter 2 caracteres.");

            RuleFor(x => x.Pais)
                .NotNull()
                .WithMessage("O Pais não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Pais não pode ser nulo.")
                .MaximumLength(50)
                .WithMessage("O Pais deve ter no máximo 100 caracteres.")
                .MinimumLength(3)
                .WithMessage("O Pais deve ter no mínimo 3 caracteres.");
        }
    }
}
