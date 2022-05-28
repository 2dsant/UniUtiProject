using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IAuthRepository
    {
        Task<AuthResult> Register(UsuarioVO vo);
        Task<AuthResult> Login(LoginVO vo);
    }
}