using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class CursoResponseVO
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public long? Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. O nome deve conter até 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Nome inválido. O nome deve conter no mínimo 5 caracteres.")]
        public string? Nome { get; set; }
    }
}