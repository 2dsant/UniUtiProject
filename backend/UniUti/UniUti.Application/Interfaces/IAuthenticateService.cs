using UniUti.Application.ValueObjects;

namespace UniUti.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<UserToken> Authenticate(string email, string password);
        Task<UsuarioResponseVO> RegisterUser(UsuarioRegistroVO usuario);
        Task<string> GenerateToken(string email);
        Task<UserToken> RefreshToken(string userId);
        //Task Logout();
    }
}
