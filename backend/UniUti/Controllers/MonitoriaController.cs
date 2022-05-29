using Microsoft.AspNetCore.Mvc;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Repository;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MonitoriaController : ControllerBase
    {
        private IMonitoriaRepository _repository;

        public MonitoriaController(IMonitoriaRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitoriaVO>>> FindAll()
        {
            var monitorias = await _repository.FindAll();
            if (monitorias == null) return NotFound();
            return Ok(monitorias);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<InstituicaoVO>> FindById(long id)
        {
            var monitoria = await _repository.FindById(id);
            if (monitoria == null) return NotFound();
            return Ok(monitoria);
        }

        [HttpGet("GetByStatus/{status}")]
        public async Task<ActionResult<MonitoriaVO>> FindByStatus(long status)
        {
            var monitoria = await _repository.FindByStatus(status);
            if (monitoria == null) return NotFound();
            return Ok(monitoria);
        }

        [HttpPost]
        public async Task<ActionResult<MonitoriaVO>> Create([FromBody] CriarMonitoriaVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var monitoria = await _repository.Create(vo);
                    return Ok(monitoria);
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorResponse()
                    {
                        Errors = new List<string>()
                        {
                            ex.Message
                        }
                    });
                }
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MonitoriaVO>> Update([FromBody] MonitoriaVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var monitoria = await _repository.Update(vo);
                    return Ok(monitoria);
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorResponse()
                    {
                        Errors = new List<string>()
                        {
                            ex.Message
                        }
                    });
                }
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}