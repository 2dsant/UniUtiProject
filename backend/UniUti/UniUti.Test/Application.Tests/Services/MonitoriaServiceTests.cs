using UniUti.Application.ValueObjects;
using UniUti.Application.Services;
using UniUti.Domain.Models.Enum;
using UniUti.Domain.Interfaces;
using UniUti.Domain.Models;
using UniUti.Config;
using AutoMapper;
using Xunit;
using Moq;

namespace UniUti.Test.Application.Tests.Services
{
    public class MonitoriaServiceTests
    {
        private readonly Mock<IMonitoriaRepository> _service;
        private readonly IMapper _mapper;
        private readonly MonitoriaService _monitoria;

        public MonitoriaServiceTests()
        {
            if (_mapper == null)
            {
                IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
                _mapper = mapper;
            }

            _service = new Mock<IMonitoriaRepository>();
            _monitoria = new MonitoriaService(_service.Object, _mapper);
        }

        [Fact]
        public async Task Find_all_should_return_instituicao_success()
        {
            //Arrange
            var monitoria = new List<Monitoria>()
            {
                new Monitoria()
                {
                    SolicitanteId = Guid.NewGuid(),
                    PrestadorId = Guid.NewGuid(),
                    Descricao = "Descricao monitoria teste.",
                    TipoSolicitacao = TipoSolicitacao.Solicitar,
                    StatusSolicitacaco = StatusSolicitacao.Aguardando
                }
            };

            //Action
            _service.Setup(x => x.FindAll()).ReturnsAsync(monitoria);
            var result = await _monitoria.FindAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task Find_all_should_return_null()
        {
            //Arrange
            var monitoria = new List<Monitoria>();

            //Action
            _service.Setup(x => x.FindAll()).ReturnsAsync(monitoria);
            var result = await _monitoria.FindAll();

            //Assert
            Assert.False(result.Any());
        }

        [Fact]
        public async Task Find_by_id_should_return_instituicao()
        {
            //Arrange
            var monitoria = new Monitoria()
            {
                SolicitanteId = Guid.NewGuid(),
                PrestadorId = Guid.NewGuid(),
                Descricao = "Descricao monitoria teste.",
                TipoSolicitacao = TipoSolicitacao.Solicitar,
                StatusSolicitacaco = StatusSolicitacao.Aguardando
            };

            //Action
            _service.Setup(x => x.FindById(It.IsAny<long>())).ReturnsAsync(monitoria);
            var result = await _monitoria.FindById(It.IsAny<long>());

            //Assert
            Assert.Equal(result.Id.ToString(), monitoria.Id.ToString());
        }

        [Fact]
        public async Task Create_success()
        {
            //Arrange
            var monitoria = new Monitoria()
            {
                SolicitanteId = Guid.NewGuid(),
                PrestadorId = Guid.NewGuid(),
                Descricao = "Descricao monitoria teste.",
                TipoSolicitacao = TipoSolicitacao.Solicitar,
                StatusSolicitacaco = StatusSolicitacao.Aguardando
            };

            //Action
            _service.Setup(x => x.Create(monitoria)).ReturnsAsync(monitoria);
            var exception = Record.ExceptionAsync(() => _monitoria.Create(It.IsAny<MonitoriaCreateVO>())); 

            //Assert
            Assert.Null(exception.Exception);
        }

        [Fact]
        public async Task Update_success()
        {
            //Arrange
            var monitoria = new Monitoria()
            {
                SolicitanteId = Guid.NewGuid(),
                PrestadorId = Guid.NewGuid(),
                Descricao = "Descricao monitoria teste.",
                TipoSolicitacao = TipoSolicitacao.Solicitar,
                StatusSolicitacaco = StatusSolicitacao.Aguardando
            };

            //Action
            _service.Setup(x => x.Update(monitoria)).ReturnsAsync(monitoria);
            var exception = Record.ExceptionAsync(() => _monitoria.Update(It.IsAny<MonitoriaUpdateVO>()));

            //Assert
            Assert.Null(exception.Exception);
        }
    }
}