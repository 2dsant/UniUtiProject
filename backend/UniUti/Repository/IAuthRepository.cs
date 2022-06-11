using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IAuthRepository
    {
        Task<AuthResult> Register(UsuarioRegistroVO vo);
        Task<AuthResult> Login(UsuarioLoginVO vo);
    }
}