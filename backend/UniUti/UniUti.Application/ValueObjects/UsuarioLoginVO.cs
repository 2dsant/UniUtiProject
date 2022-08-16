using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class UsuarioLoginVO
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string? Senha { get; set; }
    }
}