
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Models.Base;

namespace UniUti.Models
{
    [Table("instituicoes")]
    public class Instituicao : EntidadeBase
    {
        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string? Nome { get; set; }
        public virtual ICollection<Curso>? Cursos { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }

        [Required]
        [Column("endereco")]
        [StringLength(100)]
        public virtual Endereco? Endereco { get; set; }

        [Required]
        [Column("telefone")]
        [StringLength(10)]
        public string? Telefone { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Column("celular")]
        [StringLength(11)]
        public string? Celular { get; set; }

        [Column("deletado")]
        public Boolean Deletado { get; set; } = false;
    }
}