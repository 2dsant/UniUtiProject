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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NovoCursoVO>>> FindAll()
        {
            var cursos = await _repository.FindAll();
            if (cursos == null) return NotFound();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NovoCursoVO>> FindById(long id)
        {
            var curso = await _repository.FindById(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<NovoCursoVO>> Create([FromBody] NovoCursoVO vo)
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

        [HttpPut]
        public async Task<ActionResult<NovoCursoVO>> Update([FromBody] NovoCursoVO vo)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse>> Delete(long id)
        {
            var response = await _repository.Delete(id);
            if (!response.Success) return BadRequest();
            return Ok(response);
        }
    }
}