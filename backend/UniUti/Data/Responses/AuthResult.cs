using UniUti.Models;

namespace UniUti.Data.Responses
{
    public class AuthResult
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}