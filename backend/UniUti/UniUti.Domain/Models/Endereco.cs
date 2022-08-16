using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    [Table("enderecos")]
    public class Endereco : EntidadeBase
    {
        [Required]
        [Column("cep")]
        [StringLength(8)]
        public string? Cep { get; set; }

        [Required]
        [Column("rua")]
        [StringLength(100)]
        public string? Rua { get; set; }

        [Required]
        [Column("numero")]
        [StringLength(8)]
        public string? Numero { get; set; }

        [Required]
        [Column("cidade")]
        [StringLength(50)]
        public string? Cidade { get; set; }

        [Required]
        [Column("estado")]
        [StringLength(2)]
        public string? Estado { get; set; }

        [Required]
        [Column("pais")]
        [StringLength(50)]
        public string? Pais { get; set; }
    }
}