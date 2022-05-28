using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Database;
using UniUti.Models;

namespace UniUti.Repository
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public InstituicaoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstituicaoVO>> FindAll()
        {
            List<Instituicao> instituicoes = await _context.Instituicoes.Where(i =>
                i.Deletado == false).ToListAsync();
            return _mapper.Map<List<InstituicaoVO>>(instituicoes);
        }

        public async Task<InstituicaoVO> FindById(long id)
        {
            Instituicao instituicao = await _context.Instituicoes.Where(i =>
                i.Id == id && i.Deletado == false).FirstOrDefaultAsync();
            return _mapper.Map<InstituicaoVO>(instituicao);
        }

        public async Task<InstituicaoVO> Create(InstituicaoVO vo)
        {
            Instituicao instituicao = _mapper.Map<Instituicao>(vo);
            _context.Instituicoes.Add(instituicao);
            await _context.SaveChangesAsync();
            return _mapper.Map<InstituicaoVO>(instituicao);
        }

        public async Task<InstituicaoVO> Update(InstituicaoVO vo)
        {
            Instituicao instituicao = _mapper.Map<Instituicao>(vo);
            _context.Instituicoes.Update(instituicao);
            await _context.SaveChangesAsync();
            return _mapper.Map<InstituicaoVO>(instituicao);
        }

        public async Task<GenericResponse> Delete(long id)
        {
            try
            {
                Instituicao instituicao = await _context.Instituicoes.Where(i => i.Id == id)
                    .FirstOrDefaultAsync();

                if (instituicao == null)
                {
                    return (new GenericResponse()
                    {
                        Success = false,
                        Messages = new List<string>()
                        {
                            "Instituição não encontrada com id informado."
                        },
                    });
                }

                instituicao.Deletado = true;
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