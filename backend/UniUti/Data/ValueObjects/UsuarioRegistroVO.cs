using UniUti.Models;

namespace UniUti.Data.ValueObjects
{
    public class UsuarioRegistroVO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
        public string? Celular { get; set; }
        public InstituicaoVO? Instituicao { get; set; }
        public NovoCursoVO? Curso { get; set; }
    }
}