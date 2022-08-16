using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class InstituicaoCreateVO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. O nome deve conter até 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public EnderecoCreateVO? Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [MaxLength(10, ErrorMessage = "Número de telefone inválido. Número de telefone deve possuir até 10 caracteres.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Número de celular inválido. Número de celular deve possuir até 11 caracteres.")]
        public string? Celular { get; set; }
    }
}