using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class UsuarioRegistroVO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. Nome deve possuir até 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email inválido. Email deve possuir até 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório.")]
        [MaxLength(11, ErrorMessage = "Celular inválido. Celular deve possuir até 11 caracteres.")]
        public string? Celular { get; set; }

        public long? InstituicaoId { get; set; }

        public long? CursoId { get; set; }
    }
}