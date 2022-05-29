using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Models.Base;

namespace UniUti.Models
{
    [Table("disciplinas")]
    public class Disciplina : EntidadeBase
    {
        [Column("nome")]
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        public virtual ICollection<Curso>? Cursos { get; set; }

        [Column("deletado")]
        public Boolean Deletado { get; set; } = false;
    }
}