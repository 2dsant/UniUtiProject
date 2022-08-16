using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> FindAll();
        Task<Curso> FindById(long id);
        Task<Curso> Create(Curso curso);
        Task<Curso> Update(Curso curso);
        Task<bool> Delete(long id);
    }
}