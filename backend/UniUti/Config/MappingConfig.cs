using AutoMapper;
using UniUti.Data.ValueObjects;
using UniUti.Models;

namespace UniUti.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, UsuarioResponseVO>();
                config.CreateMap<UsuarioResponseVO, UsuarioResponseVO>();
                config.CreateMap<CursoResponseVO, Curso>();
                config.CreateMap<Curso, CursoResponseVO>();
                config.CreateMap<Curso, CursoCreateVO>();
                config.CreateMap<CursoCreateVO, Curso>();
                config.CreateMap<DisciplinaResponseVO, Disciplina>();
                config.CreateMap<Disciplina, DisciplinaResponseVO>();
                config.CreateMap<Disciplina, DisciplinaCreateVO>();
                config.CreateMap<DisciplinaCreateVO, Disciplina>();
                config.CreateMap<EnderecoResponseVO, Endereco>();
                config.CreateMap<Endereco, EnderecoResponseVO>();
                config.CreateMap<Endereco, EnderecoCreateVO>();
                config.CreateMap<EnderecoCreateVO, Endereco>();
                config.CreateMap<InstituicaoResponseVO, Instituicao>();
                config.CreateMap<Instituicao, InstituicaoResponseVO>();
                config.CreateMap<Instituicao, InstituicaoCreateVO>();
                config.CreateMap<InstituicaoCreateVO, Instituicao>();
                config.CreateMap<MonitoriaResponseVO, Monitoria>();
                config.CreateMap<Monitoria, MonitoriaResponseVO>();
                config.CreateMap<MonitoriaCreateVO, Monitoria>()
                    .ForMember(dst => dst.Disciplina,
                        map => map.MapFrom(src => new Disciplina() { Id = src.DisciplinaId }))
                    .ForMember(dst => dst.Solicitante,
                        map => map.MapFrom(src => new Usuario() { Id = src.SolicitanteId }));

                config.CreateMap<Monitoria, MonitoriaCreateVO>()
                    .ForMember(dst => dst.DisciplinaId,
                        map => map.MapFrom(src => src.Disciplina.Id))
                    .ForMember(dst => dst.SolicitanteId,
                        map => map.MapFrom(src => src.Solicitante.Id));

                config.CreateMap<MonitoriaUpdateVO, Monitoria>()
                    .ForMember(dst => dst.Disciplina,
                        map => map.MapFrom(src => new Disciplina() { Id = src.DisciplinaId }))
                    .ForMember(dst => dst.Prestador,
                        map => map.MapFrom(src => src.PrestadorId == null ? new Usuario() : new Usuario() { Id = (long)src.PrestadorId }));

                config.CreateMap<Monitoria, MonitoriaUpdateVO>()
                    .ForMember(dst => dst.DisciplinaId,
                        map => map.MapFrom(src => src.Disciplina.Id));
            });
            return mappingConfig;
        }
    }
}