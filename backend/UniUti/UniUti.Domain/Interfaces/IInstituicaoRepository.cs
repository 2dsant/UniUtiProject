using UniUti.Domain.Models;

namespace UniUti.Domain.Interfaces
{
    public interface IInstituicaoRepository
    {
        Task<IEnumerable<Instituicao>> FindAll();
        Task<Instituicao> FindById(string id);
        Task<Instituicao> Create(Instituicao instituicao);
        Task<Instituicao> Update(Instituicao instituicao);
        Task<bool> Delete(string id);
    }
}