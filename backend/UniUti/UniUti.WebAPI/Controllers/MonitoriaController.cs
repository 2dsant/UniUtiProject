using UniUti.Application.ValueObjects.Responses;
using Microsoft.AspNetCore.Authorization;
using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniUti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MonitoriaController : ControllerBase
    {
        private readonly IMonitoriaService _service;

        public MonitoriaController(IMonitoriaService service)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<MonitoriaResponseVO>>> FindAll()
        {
            try
            {
                var monitorias = await _service.FindAll();
                if (monitorias == null) return NotFound();
                return Ok(monitorias);
            }
            catch(Exception ex)
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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindById(long id)
        {
            try
            {
                var monitoria = await _service.FindById(id);
                if (monitoria == null) return NotFound();
                return Ok(monitoria);
            }
            catch(Exception ex)
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

        [HttpGet("GetByStatus/{status}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindByStatus(long status)
        {
            try
            {
                var monitoria = await _service.FindByStatus(status);
                if (monitoria == null) return NotFound();
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

        [HttpGet("FindByUser/{idUser}")]
        public async Task<ActionResult<MonitoriaResponseVO>> FindByUser(string idUser)
        {
            try
            {
                var monitoria = await _service.FindByUser(idUser);
                if (monitoria == null) return NotFound();
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

        [HttpPost("Create")]
        public async Task<ActionResult<MonitoriaResponseVO>> Create
        ([FromBody] MonitoriaCreateVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Create(vo);
                    return Ok(vo);
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

        [HttpPut("Update")]
        public async Task<ActionResult<MonitoriaResponseVO>> Update
            ([FromBody] MonitoriaUpdateVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(vo);
                    return Ok(vo);
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