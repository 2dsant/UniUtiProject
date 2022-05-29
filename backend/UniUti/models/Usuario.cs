using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Models.Base;

namespace UniUti.Models
{
    [Table("usuarios")]
    public class Usuario : EntidadeBase
    {
        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Column("senha_hash")]
        public byte[]? SenhaHash { get; set; }

        [Required]
        [Column("senha_salt")]
        public byte[]? SenhaSalt { get; set; }

        [Required]
        [Column("celular")]
        [StringLength(11)]
        public string? Celular { get; set; }

        [Column("instituicao")]
        public virtual Instituicao? Instituicao { get; set; }

        [Column("curso")]
        public virtual Curso? Curso { get; set; }

        [Column("deletado")]
        public Boolean Deletado { get; set; } = false;
    }
}