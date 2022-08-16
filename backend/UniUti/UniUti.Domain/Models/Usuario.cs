using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class Usuario : EntidadeBase
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public int InstituiçãoId { get; set; }
        public Instituicao Institucao { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public Boolean Deletado { get; set; } = false;
    }
}