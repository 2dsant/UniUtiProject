using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository ??
                throw new ArgumentNullException(nameof(cursoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CursoResponseVO>> FindAll()
        {
            var cursos = await _cursoRepository.FindAll();
            return _mapper.Map<IEnumerable<CursoResponseVO>>(cursos);
        }

        public async Task<CursoResponseVO> FindById(long id)
        {
            var curso = await _cursoRepository.FindById(id);
            return _mapper.Map<CursoResponseVO>(curso);
        }

        public async Task Create(CursoCreateVO vo)
        {
            var curso = _mapper.Map<Curso>(vo);
            await _cursoRepository.Create(curso);
        }

        public async Task Update(CursoResponseVO vo)
        {
            var curso = _mapper.Map<Curso>(vo);
            await _cursoRepository.Update(curso);
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _cursoRepository.Delete(id);
            return result;
        }
    }
}
