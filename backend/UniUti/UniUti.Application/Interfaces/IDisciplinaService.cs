using UniUti.Application.ValueObjects;

namespace UniUti.Application.Interfaces
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DisciplinaResponseVO>> FindAll();
        Task<DisciplinaResponseVO> FindById(long id);
        Task Create(DisciplinaCreateVO vo);
        Task Update(DisciplinaUpdateVO vo);
        Task<bool> Delete(long id);
    }
}
