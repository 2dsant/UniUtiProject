
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.models.Enum;
using UniUti.Models.Base;

namespace UniUti.Models
{
    [Table("monitorias")]
    public class Monitoria : EntidadeBase
    {
        [Required]
        [Column("solicitante")]
        public virtual Usuario? Solicitante { get; set; }

        [Column("prestador")]
        public virtual Usuario? Prestador { get; set; }

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
    }
}