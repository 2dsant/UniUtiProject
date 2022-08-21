using System;

namespace UniUti.Application.ValueObjects
{
    public class UserToken
    {
        public bool Success { get; set; }
        public UsuarioResponseVO Usuario { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
