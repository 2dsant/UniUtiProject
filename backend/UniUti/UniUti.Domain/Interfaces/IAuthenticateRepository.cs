using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface IAuthenticateRepository
    {
        Task<Usuario>? Authenticate(string email, string password);
        Task<Usuario>? RegisterUser(Usuario usuario);
        Task<Usuario>? GetApplicationUser(string email);
        Task<Usuario>? GetApplicationUserById(string userId);
        Task<string> GenerateToken(string email);
        //Task Logout();
    }
}
