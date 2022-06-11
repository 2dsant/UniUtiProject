using Microsoft.AspNetCore.Mvc;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Repository;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _repository;

        public InstituicaoController(IInstituicaoRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<InstituicaoResponseVO>>> FindAll()
        {
            var instituicoes = await _repository.FindAll();
            if (instituicoes == null) return NotFound();
            return Ok(instituicoes);
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<InstituicaoResponseVO>> FindById(long id)
        {
            var instituicao = await _repository.FindById(id);
            if (instituicao == null) return NotFound();
            return Ok(instituicao);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<InstituicaoResponseVO>> Create
        ([FromBody] InstituicaoCreateVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var instituicao = await _repository.Create(vo);
                    return Ok(instituicao);
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
        public async Task<ActionResult<InstituicaoResponseVO>> Update
        ([FromBody] InstituicaoResponseVO vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var instituicao = await _repository.Update(vo);
                    return Ok(instituicao);
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