using Microsoft.EntityFrameworkCore;
using UniUti.Domain.Models.Enum;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Database;

namespace UniUti.Infra.Data.Repositories
{
    public class MonitoriaRepository : IMonitoriaRepository
    {
        private readonly ApplicationDbContext _context;


        public MonitoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Monitoria>> FindAll()
        {
            List<Monitoria> monitorias = await _context.Monitorias.Include(x => x.Disciplina).ToListAsync();
            return monitorias;
        }

        public async Task<Monitoria> FindById(string id)
        {
            Monitoria monitoria = await _context.Monitorias.Where(i =>
                i.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            _context.ChangeTracker.Clear();
            return monitoria;
        }

        public async Task<IEnumerable<Monitoria>> FindByStatus(long status)
        {
            List<Monitoria> monitorias = await _context.Monitorias.Where(m =>
                m.StatusSolicitacao == (StatusSolicitacao)status).ToListAsync();
            return monitorias;
        }

        public async Task<IEnumerable<Monitoria>> FindByUser(string idUser)
        {
            List<Monitoria> monitorias = await _context.Monitorias.Where(m => m.SolicitanteId.ToString() == idUser).ToListAsync();
            return monitorias;
        }

        public async Task<Monitoria> Create(Monitoria monitoria)
        {
            monitoria.SetSolicitanteId(monitoria.SolicitanteId);
            monitoria.SetDisciplina(await _context.Disciplinas.Where(d => d.Id == monitoria.Disciplina.Id).FirstOrDefaultAsync());
            monitoria.SetDataCriacao(DateTime.Now);
            monitoria.SetStatusSolicitacao(StatusSolicitacao.Aberto);
            _context.Monitorias.Add(monitoria);
            await _context.SaveChangesAsync();
            return monitoria;
        }

        public async Task<Monitoria> Update(Monitoria monitoria)
        {
            monitoria.SetPrestadoId(monitoria.PrestadorId);
            monitoria.SetDisciplina(await _context.Disciplinas.Where(d => d.Id == monitoria.Disciplina.Id).FirstOrDefaultAsync());
            monitoria.SetDescricao(monitoria.Descricao);
            monitoria.SetStatusSolicitacao(monitoria.StatusSolicitacao.Value);
            _context.Monitorias.Update(monitoria);
            await _context.SaveChangesAsync();
            return monitoria;
        }
    }
}