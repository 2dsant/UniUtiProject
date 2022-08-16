using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class DisciplinaUpdateVO
    {
        [Required(ErrorMessage = "Id � obrigat�rio.")]
        public long? Id { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio.")]
        [MaxLength(100, ErrorMessage = "Nome inv�lido. O nome deve conter at� 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Nome inv�lido. O nome deve conter no m�nimo 5 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Descri��o � obrigat�rio.")]
        [MaxLength(800, ErrorMessage = "Descri��o inv�lida. A Descri��o deve conter at� 800 caracteres.")]
        [MinLength(20, ErrorMessage = "Descri��o inv�lida. A Descri��o deve conter no m�nimo 20 caracteres.")]
        public string? Descricao { get; set; }
    }
}