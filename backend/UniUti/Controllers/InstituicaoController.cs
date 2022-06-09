using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstituicaoVO>>> FindAll()
        {
            var instituicoes = await _repository.FindAll();
            if (instituicoes == null) return NotFound();
            return Ok(instituicoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstituicaoVO>> FindById(long id)
        {
            var instituicao = await _repository.FindById(id);
            if (instituicao == null) return NotFound();
            return Ok(instituicao);
        }

        [HttpPost]
        public async Task<ActionResult<InstituicaoVO>> Create([FromBody] InstituicaoVO vo)
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

        [HttpPut]
        public async Task<ActionResult<InstituicaoVO>> Update([FromBody] InstituicaoVO vo)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse>> Delete(long id)
        {
            var response = await _repository.Delete(id);
            if (!response.Success) return BadRequest();
            return Ok(response);
        }
    }
}