using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoVO>> FindAll();
        Task<CursoVO> FindById(long id);
        Task<CursoVO> Create(CursoVO vo);
        Task<CursoVO> Update(CursoVO vo);
        Task<Boolean> Delete(long id);
    }
}