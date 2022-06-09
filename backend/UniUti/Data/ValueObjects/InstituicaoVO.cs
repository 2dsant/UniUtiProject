using System.ComponentModel.DataAnnotations;
using UniUti.Models;

namespace UniUti.Data.ValueObjects
{
    public class InstituicaoVO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. O nome deve conter até 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public EnderecoVO? Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [MaxLength(10, ErrorMessage = "Número de telefone inválido. Número de telefone deve possuir até 10 caracteres.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Número de celular inválido. Número de celular deve possuir até 100 caracteres.")]
        public string? Email { get; set; }

        [MaxLength(11, ErrorMessage = "Número de celular inválido. Número de celular deve possuir até 11 caracteres.")]
        public string? Celular { get; set; }
    }
}