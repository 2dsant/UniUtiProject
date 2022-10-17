using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class UsuarioRegistroVO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. Nome deve possuir até 100 caracteres.")]
        [MinLength(8, ErrorMessage = "Nome inválido. Nome deve possuir no mínimo 8 caracteres.")]
        public string? NomeCompleto { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email inválido. Email deve possuir até 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [MaxLength(30, ErrorMessage = "Senha inválida. Senha deve possuir até 30 caracteres.")]
        [MinLength(8, ErrorMessage = "Senha inválida. Senha deve possuir no mínimo 8 caracteres com caracteres especiais e letra maíuscula.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public EnderecoCreateVO? Endereco { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório.")]
        [MaxLength(11, ErrorMessage = "Celular inválido. Celular deve possuir até 11 caracteres.")]
        public string? Celular { get; set; }

        public string? InstituicaoId { get; set; }

        public string? CursoId { get; set; }
    }
}