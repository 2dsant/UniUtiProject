using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class EnderecoCreateVO
    {
        [Required]
        [MaxLength(8, ErrorMessage = "Cep inválido. Cep deve conter até 8 caracteres.")]
        [MinLength(8, ErrorMessage = "Cep inválido. Cep deve conter até 8 caracteres.")]
        public string? Cep { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Rua inválida. A rua deve conter até 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Rua inválida. A rua deve conter no mínimo 5 caracteres.")]
        public string? Rua { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Número inválido. Número deve conter até 20 caracteres.")]
        [MinLength(1, ErrorMessage = "Rua inválida. A rua deve conter no mínimo 1 caractere.")] 
        public string? Numero { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Cidade inválida. Cidade deve conter até 50 caracteres.")]
        [MinLength(5, ErrorMessage = "Cidade inválida. Cidade deve conter no mínimo 1 caractere.")]
        public string? Cidade { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Estado inválido. Estado deve conter 2 caracteres.")]
        [MinLength(2, ErrorMessage = "Estado inválido. Estado deve conter 2 caracteres.")] 
        public string? Estado { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Pais inválido. Cidade deve conter até 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Pais inválido. Cidade deve conter no mínimo 1 caractere.")]
        public string? Pais { get; set; }
    }
}