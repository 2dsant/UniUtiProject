using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<NovoCursoVO>> FindAll();
        Task<NovoCursoVO> FindById(long id);
        Task<NovoCursoVO> Create(NovoCursoVO vo);
        Task<NovoCursoVO> Update(NovoCursoVO vo);
        Task<GenericResponse> Delete(long id);
    }
}