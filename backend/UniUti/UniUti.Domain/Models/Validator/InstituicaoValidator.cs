using FluentValidation;

namespace UniUti.Domain.Models.Validator
{
    public class InstituicaoValidator : AbstractValidator<Instituicao>
    {
        public InstituicaoValidator()
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

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")
                .MaximumLength(100)
                .WithMessage("O nome deve ter no máximo 100 caracteres.")
                .MinimumLength(5)
                .WithMessage("O nome deve ter no mínimo 5 caracteres.");

            RuleFor(x => x.Endereco)
                .NotNull()
                .WithMessage("O endereco não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O endereco não pode ser vazio.");

            RuleFor(x => x.Telefone)
                .NotNull()
                .WithMessage("O telefone não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O telefone não pode ser vazio.")
                .MaximumLength(11)
                .WithMessage("O telefone deve ter até 11 caracteres.")
                .MinimumLength(8)
                .WithMessage("O telefone deve ter no mínimo 8 caracteres.");

            RuleFor(x => x.Celular)
                .Length(11)
                .WithMessage("O telefone deve ter 11 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")
                .MinimumLength(10)
                .WithMessage("O email deve ter pelo menos 3 caracteres.")
                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 100 caracteres.")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Formato de email inválido.");
        }
    }
}
