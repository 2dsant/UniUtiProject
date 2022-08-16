using Microsoft.AspNetCore.Identity;
using UniUti.Domain.Models;

namespace UniUti.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? NomeCompleto { get; set; }
        public string? Celular { get; set; }
        public int InstituicaoId { get; set; }
        public int CursoId { get; set; }

        public virtual Instituicao? Instituicao { get; set; }
        public virtual Curso? Curso { get; set; }
        public Boolean Deletado { get; set; } = false;
    }
}
