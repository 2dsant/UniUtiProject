using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniUti.Database;
using UniUti.models;
using UniUti.models.dtos;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public AuthController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Usuario>> Register(UsuarioDto userDto)
        {
            Usuario usuarioBd = new Usuario();
            usuarioBd.Nome = userDto.Nome;
            usuarioBd.Email = userDto.Email;
            usuarioBd.Senha = userDto.Senha;
            usuarioBd.Celular = userDto.Celular;

            await _database.Usuarios.AddAsync(usuarioBd);
            await _database.SaveChangesAsync();

            return Ok(usuarioBd);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            Usuario UsuarioBd = _database.Usuarios.FirstOrDefault(Usuario =>
                Usuario.Email == login.Email && Usuario.Senha == login.Senha
            );

            if (UsuarioBd != null)
            {
                return Ok("TOKEN JWT");
            }
            else
            {
                return NotFound("Usuário não encontrado com os dados informados");
            }

        }

        // private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        // {
        //     using (var hmac = new HMACSHA512())
        //     {
        //         passwordSalt = hmac.Key;
        //         passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //     }

    }
}