using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UniUti.Infra.Data.Identity;
using Microsoft.AspNetCore.Mvc;
using UniUti.Domain.Interfaces;
using UniUti.WebAPI.ViewModels;
using System.Security.Claims;
using System.Text;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthenticateRepository _authentication;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthenticateRepository authentication, IConfiguration configuration, 
            UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _userManager = userManager;
            _accessor = accessor;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);
            if (!result)
            {
                ModelState.AddModelError(String.Empty, "Tentativa de login inválida.");
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            return GenerateToken(user);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] RegisterModel userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.Nome, userInfo.Email, 
                userInfo.Password, userInfo.Celular, userInfo.InstituiçãoId, userInfo.CursoId);
            if (!result)
            {
                ModelState.AddModelError(String.Empty, "Tentativa de criar usuário inválida.");
                return BadRequest(ModelState);
            }

            return Ok($"Usuário {userInfo.Email} foi criado com sucesso.");
        }

        private UserToken GenerateToken(ApplicationUser userInfo)
        {
            //Declarações do usuario
            var claims = new[]
            {
                new Claim("id", userInfo.Id),
                new Claim("email", userInfo.Email),
                new Claim("nomeCompleto", userInfo.NomeCompleto),
                new Claim("celular", userInfo.Celular),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir tempo de expiração do token
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);
            if (usuario == null) return NotFound("Usuário não encontrado");

            return Ok(GenerateToken(usuario));
        }
    }
}