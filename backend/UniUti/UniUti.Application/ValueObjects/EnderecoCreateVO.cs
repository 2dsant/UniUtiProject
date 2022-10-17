using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class EnderecoCreateVO
    {
        [Required]
        [MaxLength(8, ErrorMessage = "Cep inv�lido. Cep deve conter at� 8 caracteres.")]
        [MinLength(8, ErrorMessage = "Cep inv�lido. Cep deve conter at� 8 caracteres.")]
        public string? Cep { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Rua inv�lida. A rua deve conter at� 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Rua inv�lida. A rua deve conter no m�nimo 5 caracteres.")]
        public string? Rua { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "N�mero inv�lido. N�mero deve conter at� 20 caracteres.")]
        [MinLength(1, ErrorMessage = "Rua inv�lida. A rua deve conter no m�nimo 1 caractere.")] 
        public string? Numero { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Cidade inv�lida. Cidade deve conter at� 50 caracteres.")]
        [MinLength(5, ErrorMessage = "Cidade inv�lida. Cidade deve conter no m�nimo 1 caractere.")]
        public string? Cidade { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Estado inv�lido. Estado deve conter 2 caracteres.")]
        [MinLength(2, ErrorMessage = "Estado inv�lido. Estado deve conter 2 caracteres.")] 
        public string? Estado { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Pais inv�lido. Cidade deve conter at� 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Pais inv�lido. Cidade deve conter no m�nimo 1 caractere.")]
        public string? Pais { get; set; }
    }
}