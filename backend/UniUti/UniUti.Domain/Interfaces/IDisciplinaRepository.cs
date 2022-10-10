using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> FindAll();
        Task<Disciplina> FindById(string id);
        Task<Disciplina> Create(Disciplina curso);
        Task<Disciplina> Update(Disciplina curso);
        Task<bool> Delete(string id);
    }
}
