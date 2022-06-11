using System.ComponentModel.DataAnnotations;

namespace UniUti.Data.ValueObjects
{
    public class UsuarioResponseVO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. Nome deve possuir até 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email inválido. Email deve possuir até 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório.")]
        [MaxLength(11, ErrorMessage = "Celular inválido. Celular deve possuir até 11 caracteres.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "instituição é obrigatório.")]
        public InstituicaoResponseVO? Instituicao { get; set; }

        [Required(ErrorMessage = "Curso é obrigatório.")]
        public CursoResponseVO? Curso { get; set; }
    }
}