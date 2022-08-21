namespace UniUti.Application.ValueObjects
{
    public class UsuarioResponseVO
    {
        public string Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public InstituicaoResponseVO? Instituicao { get; set; }
        public CursoResponseVO? Curso { get; set; }
    }
}