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

        public async Task<IEnumerable<MonitoriaVO>> FindAll()
        {
            List<Monitoria> monitorias = await _context.Monitorias.ToListAsync();
            return _mapper.Map<List<MonitoriaVO>>(monitorias);
        }

        public async Task<MonitoriaVO> FindById(long id)
        {
            Monitoria monitoria = await _context.Monitorias.Where(i =>
                i.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<MonitoriaVO>(monitoria);
        }

        public async Task<MonitoriaVO> FindByStatus(long status)
        {
            Monitoria monitoria = await _context.Monitorias.Where(i =>
                i.StatusSolicitacaco == (StatusSolicitacao)status).FirstOrDefaultAsync();
            return _mapper.Map<MonitoriaVO>(monitoria);
        }

        public async Task<MonitoriaVO> Create(CriarMonitoriaVO vo)
        {
            try
            {
                Monitoria monitoria = _mapper.Map<Monitoria>(vo);
                monitoria.Prestador = await _context.Usuarios.Where(u => u.Id == vo.PrestadorId).FirstOrDefaultAsync();
                monitoria.Solicitante = await _context.Usuarios.Where(u => u.Id == vo.SolicitanteId).FirstOrDefaultAsync();
                monitoria.Disciplina = await _context.Disciplinas.Where(d => d.Id == vo.DisciplinaId).FirstOrDefaultAsync();
                monitoria.DataCriacao = DateTime.Now;
                _context.Monitorias.Add(monitoria);
                await _context.SaveChangesAsync();
                return _mapper.Map<MonitoriaVO>(monitoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MonitoriaVO> Update(MonitoriaVO vo)
        {
            Monitoria monitoria = _mapper.Map<Monitoria>(vo);
            _context.Monitorias.Update(monitoria);
            await _context.SaveChangesAsync();
            return _mapper.Map<MonitoriaVO>(monitoria);
        }

    }
}