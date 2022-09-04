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
            List<Monitoria> monitorias = await _context.Monitorias.ToListAsync();
            return monitorias;
        }

        public async Task<Monitoria> FindById(long id)
        {
            Monitoria monitoria = await _context.Monitorias.Where(i =>
                i.Id == id).FirstOrDefaultAsync();
            _context.ChangeTracker.Clear();
            return monitoria;
        }

        public async Task<IEnumerable<Monitoria>> FindByStatus(long status)
        {
            List<Monitoria> monitorias = await _context.Monitorias.Where(m =>
                m.StatusSolicitacaco == (StatusSolicitacao)status).ToListAsync();
            return monitorias;
        }

        public async Task<IEnumerable<Monitoria>> FindByUser(string idUser)
        {
            List<Monitoria> monitorias = await _context.Monitorias.Where(m => m.SolicitanteId.ToString() == idUser).ToListAsync();
            return monitorias;
        }

        public async Task<Monitoria> Create(Monitoria monitoria)
        {
            monitoria.SolicitanteId = monitoria.SolicitanteId;
            monitoria.Disciplina = await _context.Disciplinas.Where(d => d.Id == monitoria.Disciplina.Id).FirstOrDefaultAsync();
            monitoria.DataCriacao = DateTime.Now;
            monitoria.StatusSolicitacaco = StatusSolicitacao.Aberto;
            _context.Monitorias.Add(monitoria);
            await _context.SaveChangesAsync();
            return monitoria;
        }

        public async Task<Monitoria> Update(Monitoria monitoria)
        {
            monitoria.PrestadorId = monitoria.PrestadorId;
            monitoria.Disciplina = await _context.Disciplinas.Where(d => d.Id == monitoria.Disciplina.Id).FirstOrDefaultAsync();
            monitoria.Descricao = monitoria.Descricao;
            monitoria.StatusSolicitacaco = monitoria.StatusSolicitacaco;
            _context.Monitorias.Update(monitoria);
            await _context.SaveChangesAsync();
            return monitoria;
        }
    }
}