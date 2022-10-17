using UniUti.Application.ValueObjects.Responses;
using Microsoft.AspNetCore.Authorization;
using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UniUti.WebAPI.ViewModels;

namespace UniUti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _service;

        public InstituicaoController(IInstituicaoService service)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<InstituicaoResponseVO>>> FindAll()
        {
            try
            {
                var instituicoes = await _service.FindAll();
                if (instituicoes == null) return NotFound();
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Data = instituicoes
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
        public async Task<ActionResult<InstituicaoResponseVO>> FindById(string id)
        {
            try
            {
                var instituicao = await _service.FindById(id);
                if (instituicao == null) return NotFound();
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Data = instituicao
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
        public async Task<ActionResult<InstituicaoResponseVO>> Create
        ([FromBody] InstituicaoCreateVO vo)
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
        public async Task<ActionResult<InstituicaoResponseVO>> Update
            ([FromBody] InstituicaoResponseVO vo)
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
        public async Task<ActionResult<GenericResponse>> Delete(string id)
        {
            var response = await _service.Delete(id);
            if (!response) return BadRequest();
            return Ok("Instituição Deletada");
        }
    }
}