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
                config.CreateMap<DisciplinaResponseVO, Disciplina>().ReverseMap();
                config.CreateMap<Disciplina, DisciplinaCreateVO>().ReverseMap();
                config.CreateMap<Disciplina, DisciplinaUpdateVO>().ReverseMap();
                config.CreateMap<EnderecoResponseVO, Endereco>().ReverseMap();
                config.CreateMap<Endereco, EnderecoCreateVO>().ReverseMap();
                config.CreateMap<InstituicaoResponseVO, Instituicao>().ReverseMap();
                config.CreateMap<Instituicao, InstituicaoCreateVO>().ReverseMap();
                config.CreateMap<MonitoriaResponseVO, Monitoria>().ReverseMap();
                config.CreateMap<MonitoriaCreateVO, Monitoria>()
                    .ForMember(dst => dst.Disciplina,
                        map => map.MapFrom(src => new Disciplina() { Id = src.DisciplinaId })).ReverseMap();

                //config.CreateMap<Monitoria, MonitoriaCreateVO>()
                //    .ForMember(dst => dst.DisciplinaId,
                //        map => map.MapFrom(src => src.Disciplina.Id));

                config.CreateMap<MonitoriaUpdateVO, Monitoria>()
                    .ForMember(dst => dst.Disciplina,
                        map => map.MapFrom(src => new Disciplina() { Id = src.DisciplinaId })).ReverseMap();

                //config.CreateMap<Monitoria, MonitoriaUpdateVO>()
                //    .ForMember(dst => dst.DisciplinaId,
                //        map => map.MapFrom(src => src.Disciplina.Id));
            });
            return mappingConfig;
        }
    }
}