using System.ComponentModel.DataAnnotations;
using UniUti.Database;
using UniUti.models.Enum;
using UniUti.Models;

namespace UniUti.Data.ValueObjects
{
    public class CriarMonitoriaVO
    {
        private readonly ApplicationDbContext _context;

        public long? Id { get; set; }

        [Required(ErrorMessage = "Solicitante é obrigatório.")]
        public long SolicitanteId { get; set; }

        [Required(ErrorMessage = "Prestador é obrigatório.")]
        public long PrestadorId { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [MaxLength(500, ErrorMessage = "Descrição inválida. Descrição deve possuir até 500 caracteres.")]
        [MinLength(20, ErrorMessage = "Descrição inválida. Descrição deve possuir no mínimo 20 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatório.")]
        public long DisciplinaId { get; set; }

        public DateTime? DataCriacao { get; set; }
        public StatusSolicitacao? StatusSolicitacaco { get; set; }
    }
}