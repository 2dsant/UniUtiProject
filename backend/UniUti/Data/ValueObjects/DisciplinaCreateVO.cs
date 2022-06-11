using System.ComponentModel.DataAnnotations;

namespace UniUti.Data.ValueObjects
{
    public class DisciplinaCreateVO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome inválido. O nome deve conter até 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Nome inválido. O nome deve conter no mínimo 5 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [MaxLength(800, ErrorMessage = "Descrição inválida. A Descrição deve conter até 800 caracteres.")]
        [MinLength(20, ErrorMessage = "Descrição inválida. A Descrição deve conter no mínimo 20 caracteres.")]
        public string? Descricao { get; set; }
    }
}