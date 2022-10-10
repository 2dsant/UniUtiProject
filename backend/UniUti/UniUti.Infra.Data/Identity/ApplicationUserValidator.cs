using FluentValidation;

namespace UniUti.Infra.Data.Identity
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
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

            RuleFor(x => x.NomeCompleto)
                .NotNull()
                .WithMessage("O NomeCompleto não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O NomeCompleto não pode ser vazio.")
                .MaximumLength(100)
                .WithMessage("Nome inválido. Nome deve possuir até 100 caracteres.")
                .MinimumLength(8)
                .WithMessage("Nome inválido. Nome deve possuir no mínimo 8 caracteres.");

            RuleFor(x => x.PasswordHash)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")
                .MinimumLength(6)
                .WithMessage("A senha deve ter pelo menos 8 caracteres.")
                .MaximumLength(30)
                .WithMessage("A senha deve ter no máximo 30 caracteres.");

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .WithMessage("Endereço não pode ser vazio.")
                .NotNull()
                .WithMessage("Endereço não pode ser nulo.");

            RuleFor(x => x.Celular)
                .NotNull()
                .WithMessage("TipoSolicitação não pode ser nula.")
                .NotEmpty()
                .WithMessage("TipoSolicitação não pode ser vazia.")
                .Length(11)
                .WithMessage("O telefone deve ter 11 caracteres.");
        }
    }
}
