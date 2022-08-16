
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    [Table("instituicoes")]
    public class Instituicao : EntidadeBase
    {
        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string? Nome { get; set; }

        public virtual ICollection<Curso>? Cursos { get; set; }

        [NotMapped]
        public virtual ICollection<string>? UsuariosId { get; set; }

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