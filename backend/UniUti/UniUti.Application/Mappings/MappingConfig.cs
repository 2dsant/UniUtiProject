using UniUti.Application.ValueObjects;
using UniUti.Domain.Models;
using AutoMapper;

namespace UniUti.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CursoResponseVO, Curso>().ReverseMap();
                config.CreateMap<Curso, CursoCreateVO>().ReverseMap();
                config.CreateMap<Usuario, UsuarioRegistroVO>().ReverseMap();
                config.CreateMap<Usuario, UsuarioResponseVO>().ReverseMap();
                config.CreateMap<Usuario, UsuarioLoginVO>().ReverseMap();
                config.CreateMap<Usuario, UsuarioVO>().ReverseMap();
                config.CreateMap<DisciplinaResponseVO, Disciplina>().ReverseMap();
                config.CreateMap<Disciplina, DisciplinaCreateVO>().ReverseMap();
                config.CreateMap<Disciplina, DisciplinaUpdateVO>().ReverseMap();
                config.CreateMap<EnderecoResponseVO, EnderecoInstituicao>().ReverseMap();
                config.CreateMap<EnderecoInstituicao, EnderecoCreateVO>().ReverseMap();
                config.CreateMap<EnderecoResponseVO, EnderecoUsuario>().ReverseMap();
                config.CreateMap<EnderecoUsuario, EnderecoCreateVO>().ReverseMap();
                config.CreateMap<InstituicaoResponseVO, Instituicao>().ReverseMap();
                config.CreateMap<Instituicao, InstituicaoCreateVO>().ReverseMap();
                config.CreateMap<MonitoriaResponseVO, Monitoria>().ReverseMap();
                config.CreateMap<MonitoriaCreateVO, Monitoria>().ReverseMap();

                //config.CreateMap<Monitoria, MonitoriaCreateVO>()
                //    .ForMember(dst => dst.DisciplinaId,
                //        map => map.MapFrom(src => src.Disciplina.Id));

                config.CreateMap<MonitoriaUpdateVO, Monitoria>().ReverseMap();

                //config.CreateMap<Monitoria, MonitoriaUpdateVO>()
                //    .ForMember(dst => dst.DisciplinaId,
                //        map => map.MapFrom(src => src.Disciplina.Id));
            });
            return mappingConfig;
        }
    }
}