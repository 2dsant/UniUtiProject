using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniUti.Domain.Interfaces;
using System.Security.Claims;
using UniUti.Domain.Models;
using UniUti.Database;
using System.Text;

namespace UniUti.Infra.Data.Identity
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateRepository(SignInManager<ApplicationUser> signInManage,
            UserManager<ApplicationUser> userManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _signInManager = signInManage;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<Usuario> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,
                password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                user.Endereco = _context.EnderecosUsuario.AsNoTracking().First(x => x.ApplicationUserId == user.Id && x.Deletado == false);
                return new Usuario(Guid.Parse(user.Id), user.NomeCompleto, user.PasswordHash, user.Email,
                    null, null, user.Celular, user.Enderecos?.ToList(), user.Endereco, user.Instituicao, user.Curso, user.Deletado);
            }

            return null;
        }

        public async Task<Usuario> RegisterUser(Usuario usuario)
        {
            try
            {
                var applicationUser = new ApplicationUser(usuario.Id.ToString(), usuario.NomeCompleto, usuario.Email, usuario.Celular, 
                    usuario.InstituicaoId, usuario.CursoId, usuario.MonitoriasSolicitadas, usuario.MonitoriasOfertadas, usuario.Enderecos, 
                    usuario.Endereco, usuario.Instituicao, usuario.Curso, usuario.Deletado);
                
                var result = await _userManager.CreateAsync(applicationUser, usuario.Password);

                if (result.Succeeded)
                {
                    usuario.Endereco.SetId();
                    usuario.Endereco.SetApplicationUserId(usuario.Id.ToString());
                    await _context.EnderecosUsuario.AddAsync(usuario.Endereco);
                    await _userManager.SetLockoutEnabledAsync(applicationUser, false);
                    await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                    await _context.SaveChangesAsync();
                }

                var user = await _userManager.FindByEmailAsync(usuario.Email);

                return new Usuario(Guid.Parse(user.Id), user.NomeCompleto, user.PasswordHash, user.Email,
                    null, null, user.Celular, user.Enderecos?.ToList(), user.Endereco, user.Instituicao, user.Curso, user.Deletado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Usuario>? GetApplicationUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            user.Id = await _userManager.GetUserIdAsync(user);
            if (user == null) return null;
            return new Usuario(Guid.Parse(user.Id), user.NomeCompleto, user.PasswordHash, user.Email,
                null, null, user.Celular, user.Enderecos?.ToList(), user.Endereco, user.Instituicao, user.Curso, user.Deletado);
        }

        public async Task<Usuario> GetApplicationUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.Id = await _userManager.GetUserIdAsync(user);
            return new Usuario(Guid.Parse(user.Id), user.NomeCompleto, user.PasswordHash, user.Email,
                null, null, user.Celular, user.Enderecos?.ToList(), user.Endereco, user.Instituicao, user.Curso, user.Deletado);
        }

        public async Task<string> GenerateToken(string email)
        {
            var userInfo = await _userManager.FindByEmailAsync(email);
            userInfo.Id = await _userManager.GetUserIdAsync(userInfo);
            if (userInfo is null)
            {
                throw new InvalidOperationException("Email não registrado.");
            }
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
