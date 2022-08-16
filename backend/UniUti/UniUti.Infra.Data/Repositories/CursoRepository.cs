using Microsoft.EntityFrameworkCore;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Database;

namespace UniUti.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Curso>> FindAll()
        {
            List<Curso> cursos = await _context.Cursos.Where(i =>
                i.Deletado == false).ToListAsync();
            return cursos;
        }

        public async Task<Curso> FindById(long id)
        {
            Curso curso = await _context.Cursos.Where(i =>
                i.Id == id && i.Deletado == false).FirstOrDefaultAsync();

            return curso;
        }

        public async Task<Curso> Create(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> Update(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<bool> Delete(long id)
        {
            Curso curso = await _context.Cursos.Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (curso == null)
            {
                throw new NullReferenceException("Curso não encontrado.");
            }

            curso.Deletado = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}