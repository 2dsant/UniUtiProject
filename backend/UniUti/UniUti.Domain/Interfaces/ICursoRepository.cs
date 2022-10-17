using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> FindAll();
        Task<Curso> FindById(string id);
        Task<Curso> Create(Curso curso);
        Task<Curso> Update(Curso curso);
        Task<bool> Delete(string id);
    }
}