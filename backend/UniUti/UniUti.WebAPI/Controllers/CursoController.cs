using UniUti.Application.ValueObjects.Responses;
using Microsoft.AspNetCore.Authorization;
using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UniUti.WebAPI.ViewModels;

namespace UniUti.Controllers
{
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
                if (!cursos.Any()) return NotFound();
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Data = cursos
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            ex.Message
                        }
                });
            }
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<CursoResponseVO>> FindById(string id)
        {
            try
            {
                var curso = await _service.FindById(id);
                if (curso == null) return NotFound();
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Data = curso
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            ex.Message
                        }
                });
            }
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<CursoResponseVO>> Create([FromBody] CursoCreateVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Create(vo);
                    return Ok(new ResultViewModel
                    {
                        Success = true,
                        Data = vo
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Success = false,
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
        [Authorize]
        public async Task<ActionResult<CursoResponseVO>> Update([FromBody] CursoResponseVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(vo);
                    return Ok(new ResultViewModel
                    {
                        Success = true,
                        Data = vo
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Success = false,
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
        [Authorize]
        public async Task<ActionResult<GenericResponse>> Delete(string id)
        {
            try
            {
                var response = await _service.Delete(id);
                if (!response) return NotFound();
                return Ok("Curso deletado.");
            }
            catch(Exception ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            ex.Message
                        }
                });
            }
        }
    }
}