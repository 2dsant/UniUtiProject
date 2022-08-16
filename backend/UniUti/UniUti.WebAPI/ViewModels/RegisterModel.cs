using System.ComponentModel.DataAnnotations;

namespace UniUti.WebAPI.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(70, ErrorMessage = @"O {0} deve ter pelo menos {2} e no máximo 
            {1} caracteres.", MinimumLength = 8)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório.")]
        public string? Celular { get; set; }

        public int InstituiçãoId { get; set; }
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        [StringLength(20, ErrorMessage = @"A {0}  deve ter pelo menos {2} e no máximoand at max 
            {1} caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }
        public Boolean Deletado { get; set; } = false;
    }
}
