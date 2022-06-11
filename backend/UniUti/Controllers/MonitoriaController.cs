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

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<MonitoriaResponseVO>>> FindAll()
        {
            var monitorias = await _repository.FindAll();
            if (monitorias == null) return NotFound();
            return Ok(monitorias);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindById(long id)
        {
            var monitoria = await _repository.FindById(id);
            if (monitoria == null) return NotFound();
            return Ok(monitoria);
        }

        [HttpGet("GetByStatus/{status}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindByStatus(long status)
        {
            var monitoria = await _repository.FindByStatus(status);
            if (monitoria == null) return NotFound();
            return Ok(monitoria);
        }

        [HttpGet("FindByUser/{idUser}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindByUser(long idUser)
        {
            var monitoria = await _repository.FindByUser(idUser);
            if (monitoria == null) return NotFound();
            return Ok(monitoria);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<MonitoriaResponseVO>> Create
        ([FromBody] MonitoriaCreateVO vo)
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

        [HttpPatch("Update")]
        public async Task<ActionResult<MonitoriaResponseVO>> Update
        ([FromBody] MonitoriaUpdateVO vo)
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