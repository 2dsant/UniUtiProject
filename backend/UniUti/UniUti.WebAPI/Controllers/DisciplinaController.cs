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
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<DisciplinaResponseVO>>> FindAll()
        {
            try
            {
                var disciplinas = await _service.FindAll();
                if (disciplinas == null) return NotFound();
                return Ok(disciplinas);
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

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<DisciplinaResponseVO>> FindById(long id)
        {
            try
            {
                var disciplina = await _service.FindById(id);
                if (disciplina == null) return NotFound();
                return Ok(disciplina);
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

        [HttpPost("Create")]
        public async Task<ActionResult<DisciplinaResponseVO>> Create([FromBody] DisciplinaCreateVO vo)
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
        public async Task<ActionResult<DisciplinaResponseVO>> Update([FromBody] DisciplinaUpdateVO vo)
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

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<GenericResponse>> Delete(long id)
        {
            try
            {
                var response = await _service.Delete(id);
                if (!response) return NotFound();
                return Ok("Disciplina deletada.");
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
    }
}