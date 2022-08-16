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
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<CursoResponseVO>>> FindAll()
        {
            try
            {
                var cursos = await _service.FindAll();
                if (cursos == null) return NotFound();
                return Ok(cursos);
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
        public async Task<ActionResult<CursoResponseVO>> FindById(long id)
        {
            try
            {
                var curso = await _service.FindById(id);
                if (curso == null) return NotFound();
                return Ok(curso);
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
        public async Task<ActionResult<CursoResponseVO>> Create([FromBody] CursoCreateVO vo)
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
        public async Task<ActionResult<CursoResponseVO>> Update([FromBody] CursoResponseVO vo)
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
                if (!response) return BadRequest();
                return Ok("Curso deletado.");
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