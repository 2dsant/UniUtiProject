using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class EnderecoResponseVO
    {
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