using System.ComponentModel.DataAnnotations;

namespace UniUti.Application.ValueObjects
{
    public class DisciplinaResponseVO
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}