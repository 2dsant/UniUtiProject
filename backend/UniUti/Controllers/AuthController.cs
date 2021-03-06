using Microsoft.AspNetCore.Mvc;
using UniUti.Repository;
using UniUti.Data.ValueObjects;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _repository;

        public AuthController(IAuthRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioVO vo)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.Register(vo);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginVO vo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _repository.Login(vo);
                return Ok(usuario);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}