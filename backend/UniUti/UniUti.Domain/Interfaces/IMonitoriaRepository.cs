using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface IMonitoriaRepository
    {
        Task<IEnumerable<Monitoria>> FindAll();
        Task<Monitoria> FindById(string id);
        Task<IEnumerable<Monitoria>> FindByStatus(long status);
        Task<IEnumerable<Monitoria>> FindByUser(string idUser);
        Task<Monitoria> Create(Monitoria monitoria);
        Task<Monitoria> Update(Monitoria monitoria);
    }
}