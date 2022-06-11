using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniUti.Data.Responses;
using UniUti.Data.ValueObjects;
using UniUti.Database;
using UniUti.Models;
using UniUti.Utils;

namespace UniUti.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AuthResult> Login(UsuarioLoginVO vo)
        {
            Usuario usuario = await _context.Usuarios.Where(user => user.Email == vo.Email && user.Deletado == false)
                .FirstOrDefaultAsync();

            if (usuario != null)
            {
                if (!SenhaService.VerifyPasswordHash(vo.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    return (new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Senha incorreta."
                        },
                        Success = false
                    });
                }
                string token = TokenService.CreateToken(usuario, _configuration);
                return (new AuthResult()
                {
                    Token = token,
                    Usuario = _mapper.Map<UsuarioResponseVO>(_context.Usuarios.FirstOrDefault(u => u.Email == vo.Email)),
                    Success = true,
                });
            }
            else
            {
                return (new AuthResult()
                {
                    Errors = new List<string>()
                        {
                            "Email já cadastrado."
                        },
                    Success = false
                });
            }
        }

        public async Task<AuthResult> Register(UsuarioRegistroVO vo)
        {
            Usuario usuarioExistente = _context.Usuarios.FirstOrDefault(user => user.Email == vo.Email && user.Deletado == false);

            if (usuarioExistente != null)
            {
                return (new AuthResult()
                {
                    Errors = new List<string>()
                        {
                            "Email já cadastrado."
                        },
                    Success = false
                });
            }

            try
            {
                SenhaService.CreatePasswordHash(vo.Senha, out byte[] passwordHash, out byte[] passwordSalt);
                Usuario usuario = new Usuario()
                {
                    Nome = vo.Nome,
                    Email = vo.Email,
                    SenhaHash = passwordHash,
                    SenhaSalt = passwordSalt,
                    Celular = vo.Celular,
                    Instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == vo.InstituicaoId),
                    Curso = _context.Cursos.FirstOrDefault(c => c.Id == vo.CursoId)
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return (new AuthResult()
                {
                    Success = true,
                    Usuario = _mapper.Map<UsuarioResponseVO>(usuario),
                });
            }
            catch (Exception ex)
            {
                return (new AuthResult()
                {
                    Errors = new List<string>()
                        {
                            ex.Message
                        },
                    Success = false
                });
            }
        }
    }
}