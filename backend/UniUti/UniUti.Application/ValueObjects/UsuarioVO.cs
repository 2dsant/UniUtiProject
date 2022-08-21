namespace UniUti.Application.ValueObjects
{
    public class UsuarioVO
    {
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
        public string? Celular { get; set; }
        public InstituicaoResponseVO? Instituicao { get; set; }
        public CursoResponseVO? Curso { get; set; }
    }
}