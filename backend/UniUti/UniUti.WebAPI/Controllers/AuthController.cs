using Microsoft.AspNetCore.Authorization;
using UniUti.Application.ValueObjects;
using Microsoft.AspNetCore.Identity;
using UniUti.Application.Interfaces;
using UniUti.Infra.Data.Identity;
using Microsoft.AspNetCore.Mvc;
using UniUti.WebAPI.ViewModels;
using System.Security.Claims;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthenticateService _authentication;

        public AuthController(IAuthenticateService authentication, IConfiguration configuration, 
            UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);
            if (!result.Success)
            {
                ModelState.AddModelError(String.Empty, "Tentativa de login inválida.");
                return BadRequest(ModelState);
            }
            return result;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UsuarioRegistroVO userInfo)
        {
            try
            {
                var result = await _authentication.RegisterUser(userInfo);
                return Ok($"Usuário {userInfo.Email} foi criado com sucesso.");
            }
            catch(Exception)
            {
                ModelState.AddModelError(String.Empty, "Tentativa de criar usuário inválida.");
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPost("refresh-login")]
        public async Task<ActionResult<UserToken>> RefreshLogin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var usuarioId = identity?.FindFirst("id")?.Value;
            if (usuarioId == null)
                return BadRequest();

            var resultado = await _authentication.RefreshToken(usuarioId);

            if (resultado.Success)
                return Ok(resultado);

            return Unauthorized(resultado);
        }
    }
}