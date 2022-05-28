using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;

namespace UniUti.Repository
{
    public interface IInstituicaoRepository
    {
        Task<IEnumerable<InstituicaoVO>> FindAll();
        Task<InstituicaoVO> FindById(long id);
        Task<InstituicaoVO> Create(InstituicaoVO vo);
        Task<InstituicaoVO> Update(InstituicaoVO vo);
        Task<GenericResponse> Delete(long id);
    }
}