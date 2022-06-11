using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoResponseVO>> FindAll();
        Task<CursoResponseVO> FindById(long id);
        Task<CursoResponseVO> Create(CursoCreateVO vo);
        Task<CursoResponseVO> Update(CursoResponseVO vo);
        Task<GenericResponse> Delete(long id);
    }
}