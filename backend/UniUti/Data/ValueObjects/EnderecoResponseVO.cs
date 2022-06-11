using System.ComponentModel.DataAnnotations;

namespace UniUti.Data.ValueObjects
{
    public class EnderecoResponseVO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string? Cep { get; set; }

        [Required]
        public string? Rua { get; set; }

        [Required]
        public string? Numero { get; set; }

        [Required]
        public string? Cidade { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public string? Pais { get; set; }
    }
}