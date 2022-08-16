using Microsoft.EntityFrameworkCore;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Database;

namespace UniUti.Infra.Data.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ApplicationDbContext _context;

        public DisciplinaRepository(ApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Disciplina>> FindAll()
        {
            List<Disciplina> disciplinas = await _context.Disciplinas.Where(i => !i.Deletado).ToListAsync();
            return disciplinas;
        }

        public async Task<Disciplina> FindById(long id)
        {
            Disciplina disciplina = await _context.Disciplinas.Where(i =>
                i.Id == id && !i.Deletado).FirstOrDefaultAsync();

            return disciplina;
        }

        public async Task<Disciplina> Create(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina> Update(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<bool> Delete(long id)
        {
            Disciplina curso = await _context.Disciplinas.Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (curso == null)
            {
                throw new NullReferenceException("Disciplina não encontrado.");
            }

            curso.Deletado = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

