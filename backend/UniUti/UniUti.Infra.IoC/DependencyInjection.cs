using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using UniUti.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using UniUti.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using UniUti.Application.Services;
using UniUti.Infra.Data.Identity;
using Microsoft.AspNetCore.Http;
using UniUti.Domain.Interfaces;
using UniUti.Database;
using UniUti.Config;
using AutoMapper;

namespace UniUti.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            string mySqlConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>
            (options => options.UseMySql(
                mySqlConnectionString,
                ServerVersion.AutoDetect(mySqlConnectionString))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
            services.AddScoped<IMonitoriaRepository, MonitoriaRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IMonitoriaService, MonitoriaService>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            return services;
        }
    }
}
