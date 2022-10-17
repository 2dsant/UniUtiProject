using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Application.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;
        private readonly IMapper _mapper;

        public InstituicaoService(IInstituicaoRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<InstituicaoResponseVO>> FindAll()
        {
            var instituicoes = await _repository.FindAll();
            return _mapper.Map<IEnumerable<InstituicaoResponseVO>>(instituicoes);
        }

        public async Task<InstituicaoResponseVO> FindById(string id)
        {
            var instituicao = await _repository.FindById(id);
            return _mapper.Map<InstituicaoResponseVO>(instituicao);
        }

        public async Task Create(InstituicaoCreateVO vo)
        {
            var instituicao = _mapper.Map<Instituicao>(vo);
            await _repository.Create(instituicao);
        }

        public async Task Update(InstituicaoResponseVO vo)
        {
            var instituicao = _mapper.Map<Instituicao>(vo);
            await _repository.Update(instituicao);
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _repository.Delete(id);
            return result;
        }
    }
}
