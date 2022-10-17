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
            if (result == null || !result.IsValid)
            {
                return new UserToken()
                {
                    Success = false,
                    Erros = result?.Errors
                };
            }
            if (result.CursoId != null)
                result.SetCurso(await _cursoRepository.FindById(result.CursoId.ToString()));
            
            if (result.InstituicaoId != null)
                result.SetInstituicao(await _instituicaoRepository.FindById(result.InstituicaoId.ToString()));

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
                userMap.SetId();
                var result = await _authentication.RegisterUser(userMap);
                return _mapper.Map<UsuarioResponseVO>(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<UsuarioResponseVO> GetUserByEmail(string email)
        {
            try
            {
                var result = await _authentication.GetApplicationUser(email);
                return _mapper.Map<UsuarioResponseVO>(result);
            }
            catch (Exception ex)
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
