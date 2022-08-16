using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UniUti.Domain.Models.Base;
using UniUti.Domain.Models.Enum;

namespace UniUti.Domain.Models
{
    [Table("monitorias")]
    public class Monitoria : EntidadeBase
    {
        [Required]
        [Column("solicitante")]
        public virtual Guid SolicitanteId { get; set; }

        [Column("prestador")]
        public virtual Guid? PrestadorId { get; set; }

        [Required]
        [Column("descricao")]
        [StringLength(500)]
        public string? Descricao { get; set; }

        [Required]
        [Column("disciplina")]
        [StringLength(500)]
        public virtual Disciplina? Disciplina { get; set; }

        [Required]
        [Column("data_solicitacao")]
        public DateTime? DataCriacao { get; set; }

        [Required]
        [Column("status_solicitacao")]
        public StatusSolicitacao? StatusSolicitacaco { get; set; }

        [Required]
        [Column("tipo_solicitacao")]
        public StatusSolicitacao? TipoSolicitacao { get; set; }
    }
}