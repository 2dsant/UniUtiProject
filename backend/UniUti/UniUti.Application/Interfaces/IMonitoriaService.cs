using UniUti.Application.ValueObjects;

namespace UniUti.Application.Interfaces
{
    public interface IMonitoriaService
    {
        Task<IEnumerable<MonitoriaResponseVO>> FindAll();
        Task<MonitoriaResponseVO> FindById(long id);
        Task<IEnumerable<MonitoriaResponseVO>> FindByStatus(long status);
        Task<IEnumerable<MonitoriaResponseVO>> FindByUser(string idUser);
        Task Create(MonitoriaCreateVO vo);
        Task Update(MonitoriaUpdateVO vo);
    }
}
