using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IMonitoriaRepository
    {
        Task<IEnumerable<MonitoriaVO>> FindAll();
        Task<MonitoriaVO> FindById(long id);
        Task<MonitoriaVO> FindByStatus(long status);
        Task<MonitoriaVO> Create(CriarMonitoriaVO vo);
        Task<MonitoriaVO> Update(MonitoriaVO vo);
    }
}