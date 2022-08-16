using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    [Table("cursos")]
    public class Curso : EntidadeBase
    {
        [Column("nome")]
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        public virtual ICollection<Disciplina>? Disciplinas { get; set; }

        public virtual ICollection<Instituicao>? Instituicoes { get; set; }

        [Column("deletado")]
        public Boolean Deletado { get; set; } = false;
    }
}