using System.ComponentModel.DataAnnotations;
using UniUti.Domain.Models.Enum;

namespace UniUti.Application.ValueObjects
{
    public class MonitoriaUpdateVO
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public long? Id { get; set; }

        [Required(ErrorMessage = "SolicitanteId é obrigatório.")]
        public virtual Guid SolicitanteId { get; set; }
        public Guid? PrestadorId { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Descrição inválida. Descrição deve possuir até 500 caracteres.")]
        [MinLength(20, ErrorMessage = "Descrição inválida. Descrição deve possuir no mínimo 20 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatório.")]
        public long DisciplinaId { get; set; }

        [Required(ErrorMessage = "Status da solicitação é obrigatório.")]
        public StatusSolicitacao? StatusSolicitacaco { get; set; }

        [Required(ErrorMessage = "Tipo da solicitação é obrigatório.")]
        public StatusSolicitacao? TipoSolicitacao { get; set; }
    }
}