using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IInstituicaoRepository
    {
        Task<IEnumerable<InstituicaoResponseVO>> FindAll();
        Task<InstituicaoResponseVO> FindById(long id);
        Task<InstituicaoResponseVO> Create(InstituicaoCreateVO vo);
        Task<InstituicaoResponseVO> Update(InstituicaoResponseVO vo);
        Task<GenericResponse> Delete(long id);
    }
}