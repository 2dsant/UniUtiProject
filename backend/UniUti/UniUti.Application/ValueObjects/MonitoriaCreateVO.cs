using System.ComponentModel.DataAnnotations;
using UniUti.Domain.Models.Enum;

namespace UniUti.Application.ValueObjects
{
    public class MonitoriaCreateVO
    {
        [Required(ErrorMessage = "Solicitante é obrigatório.")]
        public string SolicitanteId { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Descrição inválida. Descrição deve possuir até 500 caracteres.")]
        [MinLength(20, ErrorMessage = "Descrição inválida. Descrição deve possuir no mínimo 20 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Tipo de solicitação é obrigatório.")]
        public TipoSolicitacao TipoSolicitacao { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatório.")]
        public long DisciplinaId { get; set; }
    }
}