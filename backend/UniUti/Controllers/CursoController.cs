using Microsoft.AspNetCore.Mvc;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Repository;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CursoController : ControllerBase
    {
        private ICursoRepository _repository;

        public CursoController(ICursoRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<CursoResponseVO>>> FindAll()
        {
            var cursos = await _repository.FindAll();
            if (cursos == null) return NotFound();
            return Ok(cursos);
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<CursoResponseVO>> FindById(long id)
        {
            var curso = await _repository.FindById(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CursoResponseVO>> Create([FromBody] CursoCreateVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var curso = await _repository.Create(vo);
                    return Ok(curso);
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
                    var curso = await _repository.Update(vo);
                    return Ok(curso);
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
            var response = await _repository.Delete(id);
            if (!response.Success) return BadRequest();
            return Ok(response);
        }
    }
}