using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface IMonitoriaRepository
    {
        Task<IEnumerable<Monitoria>> FindAll();
        Task<Monitoria> FindById(long id);
        Task<IEnumerable<Monitoria>> FindByStatus(long status);
        Task<IEnumerable<Monitoria>> FindByUser(string idUser);
        Task Create(Monitoria monitoria);
        Task Update(Monitoria monitoria);
    }
}