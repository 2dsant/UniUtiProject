using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniUti.Data.ValueObjects;
using UniUti.Database;
using UniUti.models.Enum;
using UniUti.Models;

namespace UniUti.Repository
{
    public class MonitoriaRepository : IMonitoriaRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public MonitoriaRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MonitoriaResponseVO>> FindAll()
        {
            List<Monitoria> monitorias = await _context.Monitorias.ToListAsync();
            return _mapper.Map<List<MonitoriaResponseVO>>(monitorias);
        }

        public async Task<MonitoriaResponseVO> FindById(long id)
        {
            Monitoria monitoria = await _context.Monitorias.Where(i =>
                i.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<MonitoriaResponseVO>(monitoria);
        }

        public async Task<MonitoriaResponseVO> FindByStatus(long status)
        {
            List<Monitoria> monitoria = await _context.Monitorias.Where(m =>
                m.StatusSolicitacaco == (StatusSolicitacao)status).ToListAsync();
            return _mapper.Map<MonitoriaResponseVO>(monitoria);
        }

        public async Task<MonitoriaResponseVO> FindByUser(long idUser)
        {
            List<Monitoria> monitoria = await _context.Monitorias.Where(m => m.Solicitante.Id == idUser).ToListAsync();
            return _mapper.Map<MonitoriaResponseVO>(monitoria);
        }

        public async Task<MonitoriaResponseVO> Create(MonitoriaCreateVO vo)
        {
            try
            {
                Monitoria monitoria = _mapper.Map<Monitoria>(vo);
                monitoria.Solicitante = await _context.Usuarios.Where(u => u.Id == vo.SolicitanteId).FirstAsync();
                monitoria.Disciplina = await _context.Disciplinas.Where(d => d.Id == vo.DisciplinaId).FirstOrDefaultAsync();
                monitoria.DataCriacao = DateTime.Now;
                monitoria.StatusSolicitacaco = StatusSolicitacao.Aberto;
                _context.Monitorias.Add(monitoria);
                await _context.SaveChangesAsync();
                return _mapper.Map<MonitoriaResponseVO>(monitoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MonitoriaResponseVO> Update(MonitoriaUpdateVO vo)
        {
            try
            {
                Monitoria monitoria = _context.Monitorias.FirstOrDefault(m => m.Id == vo.Id);
                monitoria.Prestador = await _context.Usuarios.Where(u => u.Id == vo.PrestadorId).FirstOrDefaultAsync();
                monitoria.Disciplina = await _context.Disciplinas.Where(d => d.Id == vo.DisciplinaId).FirstOrDefaultAsync();
                monitoria.Descricao = vo.Descricao;
                monitoria.StatusSolicitacaco = vo.StatusSolicitacaco;

                await _context.SaveChangesAsync();
                return _mapper.Map<MonitoriaResponseVO>(monitoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}