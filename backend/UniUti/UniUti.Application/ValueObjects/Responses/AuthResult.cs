namespace UniUti.Application.ValueObjects.Responses
{
    public class AuthResult
    {
        public string Token { get; set; }
        public UsuarioResponseVO Usuario { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}