using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models.DTOs.Responses;
using UniUti.Database;
using UniUti.models;
using UniUti.models.dtos;
using UniUti.Utils;

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
            if (ModelState.IsValid)
            {
                var emailExistente = _database.Usuarios.FirstOrDefault(user => user.Email == userDto.Email);

                if (emailExistente != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Email já cadastrado."
                        },
                        Success = false
                    });
                }

                SenhaService.CreatePasswordHash(userDto.Senha, out byte[] passwordHash, out byte[] passwordSalt);

                Usuario usuarioBd = new Usuario()
                {
                    Nome = userDto.Nome,
                    Email = userDto.Email,
                    SenhaHash = passwordHash,
                    SenhaSalt = passwordSalt,
                    Celular = userDto.Celular
                };

                try
                {
                    await _database.Usuarios.AddAsync(usuarioBd);
                    await _database.SaveChangesAsync();
                    return Ok(usuarioBd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto userDto)
        {
            var usuarioBd = _database.Usuarios.FirstOrDefault(user => user.Email == userDto.Email);
            if (usuarioBd != null)
            {
                if (!SenhaService.VerifyPasswordHash(userDto.Senha, usuarioBd.SenhaHash, usuarioBd.SenhaSalt))
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Senha incorreta."
                        },
                        Success = false
                    });
                }

                return Ok(usuarioBd);
            }
            else
            {
                return NotFound(new RegistrationResponse()
                {
                    Errors = new List<string>()
                        {
                            "Email já cadastrado."
                        },
                    Success = false
                });
            }
        }
    }
}