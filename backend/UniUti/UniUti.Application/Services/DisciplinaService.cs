using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository, IMapper mapper)
        {
            _disciplinaRepository = disciplinaRepository ??
                throw new ArgumentNullException(nameof(disciplinaRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<DisciplinaResponseVO>> FindAll()
        {
            var disciplinas = await _disciplinaRepository.FindAll();
            return _mapper.Map<IEnumerable<DisciplinaResponseVO>>(disciplinas);
        }

        public async Task<DisciplinaResponseVO> FindById(string id)
        {
            var disciplina = await _disciplinaRepository.FindById(id);
            return _mapper.Map<DisciplinaResponseVO>(disciplina);
        }

        public async Task Create(DisciplinaCreateVO vo)
        {
            var disciplina = _mapper.Map<Disciplina>(vo);
            await _disciplinaRepository.Create(disciplina);
        }

        public async Task Update(DisciplinaUpdateVO vo)
        {
            var disciplina = _mapper.Map<Disciplina>(vo);
            await _disciplinaRepository.Update(disciplina);
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _disciplinaRepository.Delete(id);
            return result;
        }
    }
}
