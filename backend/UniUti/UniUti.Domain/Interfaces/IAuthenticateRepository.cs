namespace UniUti.Domain.Interfaces
{
    public interface IAuthenticateRepository
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string nome, string email, string password, string celular, int? instituiçãoId, int? cursoId);
        Task Logout();
    }
}
