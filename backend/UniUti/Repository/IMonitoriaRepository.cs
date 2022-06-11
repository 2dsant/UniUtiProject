using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IMonitoriaRepository
    {
        Task<IEnumerable<MonitoriaResponseVO>> FindAll();
        Task<MonitoriaResponseVO> FindById(long id);
        Task<MonitoriaResponseVO> FindByStatus(long status);
        Task<MonitoriaResponseVO> FindByUser(long idUser);
        Task<MonitoriaResponseVO> Create(MonitoriaCreateVO vo);
        Task<MonitoriaResponseVO> Update(MonitoriaUpdateVO vo);
    }
}