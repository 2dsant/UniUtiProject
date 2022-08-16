using Microsoft.AspNetCore.Identity;
using UniUti.Domain.Interfaces;

namespace UniUti.Infra.Data.Identity
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateRepository(SignInManager<ApplicationUser> signInManage,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManage;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, 
                password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(
                     string nome,
                     string email,
                     string password,
                     string celular,
                     int? instituiçãoId,
                     int? cursoId
            )
        {
            var applicationUser = new ApplicationUser
            {
                NomeCompleto = nome,
                UserName = email,
                Email = email,
                Celular = celular,
                PhoneNumber = celular,
                InstituicaoId = instituiçãoId.Value,
                CursoId = cursoId.Value,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(applicationUser, password);

            if(result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(applicationUser, false);
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
