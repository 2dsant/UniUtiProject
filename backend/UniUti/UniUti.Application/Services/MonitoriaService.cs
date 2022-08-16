using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Application.Services
{
    public class MonitoriaService : IMonitoriaService
    {
        private readonly IMonitoriaRepository _repository;
        private readonly IMapper _mapper;

        public MonitoriaService(IMonitoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MonitoriaResponseVO>> FindAll()
        {
            var monitorias = await _repository.FindAll();
            return _mapper.Map<IEnumerable<MonitoriaResponseVO>>(monitorias);
        }

        public async Task<MonitoriaResponseVO> FindById(long id)
        {
            var monitoria = await _repository.FindById(id);
            return _mapper.Map<MonitoriaResponseVO>(monitoria);
        }

        public async Task<IEnumerable<MonitoriaResponseVO>> FindByStatus(long status)
        {
            var monitoria = await _repository.FindByStatus(status);
            return _mapper.Map<IEnumerable<MonitoriaResponseVO>>(monitoria);
        }

        public async Task<IEnumerable<MonitoriaResponseVO>> FindByUser(string idUser)
        {
            var monitoria = await _repository.FindByUser(idUser);
            return _mapper.Map<IEnumerable<MonitoriaResponseVO>>(monitoria);
        }

        public async Task Create(MonitoriaCreateVO vo)
        {
            var monitoria = _mapper.Map<Monitoria>(vo);
            await _repository.Create(monitoria);
        }

        public async Task Update(MonitoriaUpdateVO vo)
        {
            var monitoriaDb = await _repository.FindById(vo.Id.Value);
            var monitoria = _mapper.Map<Monitoria>(vo);
            monitoria.DataCriacao = monitoriaDb.DataCriacao;

            await _repository.Update(monitoria);
        }
    }
}
