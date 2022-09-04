using UniUti.Application.ValueObjects;
using UniUti.Application.Interfaces;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authentication;
        private readonly ICursoRepository _cursoRepository;
        private readonly IInstituicaoRepository _instituicaoRepository;
        private readonly IMapper _mapper;

        public AuthenticateService(IAuthenticateRepository authentication, IMapper mapper,
            ICursoRepository cursoRepository, IInstituicaoRepository instituicaoRepository)
        {
            _authentication = authentication;
            _mapper = mapper;
            _cursoRepository = cursoRepository;
            _instituicaoRepository = instituicaoRepository;
        }

        public async Task<UserToken> Authenticate(string email, string password)
        {
            var result = await _authentication.Authenticate(email, password);
            if(result.Id == null)
            {
                return new UserToken()
                {
                    Success = false,
                    Erros = new List<string> { "Não foi possivel realizar login, verifique suas credenciais." }
                };
            }
            result.Curso = await _cursoRepository.FindById((long)result.CursoId);
            result.Instituicao = await _instituicaoRepository.FindById((long)result.InstituicaoId);
            var token = await GenerateToken(email);
            return new UserToken()
            {
                Success = true,
                Usuario = _mapper.Map<UsuarioResponseVO>(result),
                Token = token
            };
        }

        public async Task<UsuarioResponseVO> RegisterUser(UsuarioRegistroVO usuario)
        {
            try
            {
                var userMap = _mapper.Map<Usuario>(usuario);
                var result = await _authentication.RegisterUser(userMap);
                return _mapper.Map<UsuarioResponseVO>(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> GenerateToken(string email)
        {
            var token = await _authentication.GenerateToken(email);

            return token;
        }

        //public task logout()
        //{
        //    throw new notimplementedexception();
        //}

        public async Task<UserToken> RefreshToken(string usuarioId)
        {
            var usuario = await _authentication.GetApplicationUserById(usuarioId);

            if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado.");

            var token = await GenerateToken(usuario.Email);

            return new UserToken()
            {
                Success = true,
                Usuario = _mapper.Map<UsuarioResponseVO>(usuario),
                Token = token
            };
        }
    }
}
