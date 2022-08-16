using Microsoft.EntityFrameworkCore;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Database;

namespace UniUti.Infra.Data.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly ApplicationDbContext _context;

        public InstituicaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instituicao>> FindAll()
        {
            List<Instituicao> instituicoes = await _context.Instituicoes.Where(i =>
                i.Deletado == false).ToListAsync();
            return instituicoes;
        }

        public async Task<Instituicao> FindById(long id)
        {
            Instituicao instituicao = await _context.Instituicoes.Where(i =>
                i.Id == id && i.Deletado == false).FirstOrDefaultAsync();
            return instituicao;
        }

        public async Task<Instituicao> Create(Instituicao instituicao)
        {
            _context.Instituicoes.Add(instituicao);
            await _context.SaveChangesAsync();
            return instituicao;
        }

        public async Task<Instituicao> Update(Instituicao instituicao)
        {
            _context.Instituicoes.Update(instituicao);
            await _context.SaveChangesAsync();
            return instituicao;
        }

        public async Task<bool> Delete(long id)
        {
            Instituicao instituicao = await _context.Instituicoes.Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (instituicao == null)
            {
                throw new NullReferenceException("Instituição não encontrada.");
            }

            instituicao.Deletado = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}