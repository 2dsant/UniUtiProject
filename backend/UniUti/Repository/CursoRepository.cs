using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Database;
using UniUti.Models;

namespace UniUti.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CursoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CursoResponseVO>> FindAll()
        {
            List<Curso> cursos = await _context.Cursos.Where(i =>
                i.Deletado == false).ToListAsync();

            return _mapper.Map<List<CursoResponseVO>>(cursos);
        }

        public async Task<CursoResponseVO> FindById(long id)
        {
            Curso curso = await _context.Cursos.Where(i =>
                i.Id == id && i.Deletado == false).FirstOrDefaultAsync();

            return _mapper.Map<CursoResponseVO>(curso);
        }

        public async Task<CursoResponseVO> Create(CursoCreateVO vo)
        {
            Curso curso = _mapper.Map<Curso>(vo);
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return _mapper.Map<CursoResponseVO>(curso);
        }

        public async Task<CursoResponseVO> Update(CursoResponseVO vo)
        {
            Curso curso = _mapper.Map<Curso>(vo);
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return _mapper.Map<CursoResponseVO>(curso);
        }

        public async Task<GenericResponse> Delete(long id)
        {
            try
            {
                Curso curso = await _context.Cursos.Where(i => i.Id == id)
                    .FirstOrDefaultAsync();

                if (curso == null)
                {
                    return (new GenericResponse()
                    {
                        Success = false,
                        Messages = new List<string>()
                        {
                            "Curso não encontrado com id informado."
                        },
                    });
                }

                curso.Deletado = true;
                await _context.SaveChangesAsync();
                return (new GenericResponse()
                {
                    Success = true,
                    Messages = new List<string>()
                        {
                            "Instituição deletada."
                        },
                });
            }
            catch (Exception ex)
            {
                return (new GenericResponse()
                {
                    Success = false,
                    Messages = new List<string>()
                        {
                            ex.Message
                        },
                });
            }
        }
    }
}