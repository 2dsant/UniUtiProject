using UniUti.Application.ValueObjects.Responses;
using UniUti.Application.ValueObjects;

namespace UniUti.Application.Interfaces
{
    public interface IInstituicaoService
    {
        Task<IEnumerable<InstituicaoResponseVO>> FindAll();
        Task<InstituicaoResponseVO> FindById(long id);
        Task Create(InstituicaoCreateVO vo);
        Task Update(InstituicaoResponseVO vo);
        Task<bool> Delete(long id);
    }
}
