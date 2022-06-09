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
                config.CreateMap<NovoCursoVO, Curso>();
                config.CreateMap<Curso, NovoCursoVO>();
                config.CreateMap<DisciplinaVO, Disciplina>();
                config.CreateMap<Disciplina, DisciplinaVO>();
                config.CreateMap<EnderecoVO, Endereco>();
                config.CreateMap<Endereco, EnderecoVO>();
                config.CreateMap<InstituicaoVO, Instituicao>();
                config.CreateMap<Instituicao, InstituicaoVO>();
                config.CreateMap<MonitoriaVO, Monitoria>();
                config.CreateMap<Monitoria, MonitoriaVO>();
                config.CreateMap<CriarMonitoriaVO, Monitoria>()
                .ForMember(dst => dst.Disciplina,
                    map => map.MapFrom(src => new Disciplina() { Id = src.DisciplinaId }))
                .ForMember(dst => dst.Solicitante,
                    map => map.MapFrom(src => new Usuario() { Id = src.SolicitanteId }))
                .ForMember(dst => dst.Prestador,
                    map => map.MapFrom(src => new Usuario() { Id = src.PrestadorId }));

                config.CreateMap<Monitoria, CriarMonitoriaVO>()
                .ForMember(dst => dst.DisciplinaId,
                    map => map.MapFrom(src => src.Disciplina.Id))
                .ForMember(dst => dst.PrestadorId,
                    map => map.MapFrom(src => src.Prestador.Id))
                .ForMember(dst => dst.SolicitanteId,
                    map => map.MapFrom(src => src.Solicitante.Id));
            });
            return mappingConfig;
        }
    }
}