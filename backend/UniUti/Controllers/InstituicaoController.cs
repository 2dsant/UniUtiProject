using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniUti.Database;
using UniUti.models;
using UniUti.models.dtos;
using UniUti.models.dtos.responses;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public InstituicaoController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<ActionResult<List<Instituicao>>> Get()
        {
            try
            {
                return Ok(await _database.Instituicoes?.ToListAsync());
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Instituicao>> Get(int id)
        {
            try
            {
                var instituicao = await _database.Instituicoes.FirstOrDefaultAsync(inst => inst.Id == id);

                if (instituicao != null)
                {
                    return Ok(instituicao);
                }
                else
                {
                    return NotFound("Instituição não encontrada.");
                }
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

        [HttpPost]
        public async Task<ActionResult<Instituicao>> AddInstituicao(InstituicaoDto instituicaoDto)
        {
            if (ModelState.IsValid)
            {
                Instituicao instituicaoBd = new Instituicao()
                {
                    Nome = instituicaoDto.Nome,
                    Cursos = instituicaoDto.Cursos,
                    Endereco = instituicaoDto.Endereco,
                    Telefone = instituicaoDto.Telefone,
                    Email = instituicaoDto.Email,
                    Celular = instituicaoDto.Celular
                };

                try
                {
                    await _database.Instituicoes.AddAsync(instituicaoBd);
                    await _database.SaveChangesAsync();
                    return Ok(instituicaoBd);
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
        public async Task<ActionResult<Instituicao>> EditarInstituicao(InstituicaoDto instituicaoDto)
        {
            if (ModelState.IsValid)
            {
                var instituicaoDb = _database.Instituicoes.First(i => i.Id == instituicaoDto.Id);

                if (instituicaoDb != null)
                {
                    instituicaoDb.Id = instituicaoDto.Id;
                    instituicaoDb.Nome = instituicaoDto.Nome;
                    instituicaoDb.Cursos = instituicaoDto.Cursos;
                    instituicaoDb.Endereco = instituicaoDto.Endereco;
                    instituicaoDb.Telefone = instituicaoDto.Telefone;
                    instituicaoDb.Email = instituicaoDto.Email;
                    instituicaoDb.Celular = instituicaoDto.Celular;

                    await _database.SaveChangesAsync();
                    return Ok(instituicaoDb);
                }
                else
                {
                    return NotFound("Instituição não encontrada.");
                }
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    Instituicao instituicao = _database.Instituicoes.First(inst => inst.Id == id);
                    if (instituicao != null)
                    {
                        instituicao.Deletado = true;
                        await _database.SaveChangesAsync();
                        return Ok("Registro Excluido.");
                    }
                    else
                    {
                        return BadRequest(new ErrorResponse()
                        {
                            Errors = new List<string>()
                        {
                            "Instituição não encontrada."
                        }
                        });
                    }
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
                return BadRequest("Id não informado.");
            }
        }
    }
}