using UniUti.Domain.Models.Base;

namespace UniUti.Domain.Models
{
    public class Usuario
    {
        public string? Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public int? InstituicaoId { get; set; }
        public int? CursoId { get; set; }

        public virtual Instituicao? Instituicao { get; set; }
        public virtual Curso? Curso { get; set; }
        public Boolean Deletado { get; set; } = false;
    }
}