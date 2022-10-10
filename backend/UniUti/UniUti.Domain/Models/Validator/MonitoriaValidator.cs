using FluentValidation;

namespace UniUti.Domain.Models.Validator
{
    public class MonitoriaValidator : AbstractValidator<Monitoria>
    {
        public MonitoriaValidator()
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

            RuleFor(x => x.SolicitanteId)
                .NotNull()
                .WithMessage("O solicitante não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O solicitante não pode ser vazio.");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("O solicitante não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O solicitante não pode ser vazio.")
                .MaximumLength(500)
                .WithMessage("Descrição deve conter no máximo 500 caracteres.")
                .MinimumLength(20)
                .WithMessage("Descrição deve ter no mínimo 20 caracteres.");

            RuleFor(x => x.Disciplina)
                .NotNull()
                .WithMessage("Disciplina não pode ser nula.")
                .NotEmpty()
                .WithMessage("Disciplina não pode ser vazia.");

            RuleFor(x => x.TipoSolicitacao)
                .NotNull()
                .WithMessage("TipoSolicitação não pode ser nula.")
                .NotEmpty()
                .WithMessage("TipoSolicitação não pode ser vazia.");

            RuleFor(x => x.DataCriacao)
                .NotNull()
                .WithMessage("DataCiação não pode ser nula.")
                .NotEmpty()
                .WithMessage("DataCriação não pode ser vazia.");
        }
    }
}
