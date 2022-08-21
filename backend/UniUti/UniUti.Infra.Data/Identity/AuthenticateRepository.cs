using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UniUti.Domain.Interfaces;
using System.Security.Claims;
using UniUti.Domain.Models;
using System.Text;

namespace UniUti.Infra.Data.Identity
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;


        public AuthenticateRepository(SignInManager<ApplicationUser> signInManage,
            UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManage;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Usuario> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,
                password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var usuario = await _userManager.FindByEmailAsync(email);
                return new Usuario
                {
                    Id = usuario.Id,
                    NomeCompleto = usuario.NomeCompleto,
                    Email = usuario.Email,
                    Celular = usuario.Celular,
                    InstituicaoId = usuario.InstituicaoId,
                    CursoId = usuario.CursoId,
                    Instituicao = usuario.Instituicao,
                    Curso = usuario.Curso,
                    Deletado = usuario.Deletado
                };
            }

            return new Usuario();
        }

        public async Task<Usuario> RegisterUser(Usuario usuario)
        {
            try
            {
                var applicationUser = new ApplicationUser
                {
                    NomeCompleto = usuario.NomeCompleto,
                    UserName = usuario.Email,
                    Email = usuario.Email,
                    Celular = usuario.Celular,
                    PhoneNumber = usuario.Celular,
                    InstituicaoId = usuario.InstituicaoId.Value,
                    CursoId = usuario.CursoId.Value,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(applicationUser, usuario.Password);

                if (result.Succeeded)
                {
                    await _userManager.SetLockoutEnabledAsync(applicationUser, false);
                    await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                }

                var user = await _userManager.FindByEmailAsync(usuario.Email);

                return new Usuario
                {
                    Id = user.Id,
                    NomeCompleto = user.NomeCompleto,
                    Email = user.Email,
                    Celular = user.Celular,
                    InstituicaoId = user.InstituicaoId,
                    CursoId = user.CursoId,
                    Instituicao = user.Instituicao,
                    Curso = user.Curso,
                    Deletado = user.Deletado
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Usuario> GetApplicationUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return new Usuario
            {
                Id = user.Id,
                NomeCompleto = user.NomeCompleto,
                Email = user.Email,
                Celular = user.Celular,
                InstituicaoId = user.InstituicaoId,
                CursoId = user.CursoId,
                Instituicao = user.Instituicao,
                Curso = user.Curso,
                Deletado = user.Deletado
            };
        }

        public async Task<Usuario> GetApplicationUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return new Usuario
            {
                Id = user.Id,
                NomeCompleto = user.NomeCompleto,
                Email = user.Email,
                Celular = user.Celular,
                InstituicaoId = user.InstituicaoId,
                CursoId = user.CursoId,
                Instituicao = user.Instituicao,
                Curso = user.Curso,
                Deletado = user.Deletado
            };
        }

        public async Task<string> GenerateToken(string email)
        {
            var userInfo = await _userManager.FindByEmailAsync(email);

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
            var expiration = DateTime.UtcNow.AddMinutes(30);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            var tokenJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJwt;
        }

        //public async Task Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //}
    }
}
