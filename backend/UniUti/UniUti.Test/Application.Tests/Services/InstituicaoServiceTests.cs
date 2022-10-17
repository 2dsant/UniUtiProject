//using UniUti.Application.ValueObjects;
//using UniUti.Application.Services;
//using UniUti.Domain.Interfaces;
//using UniUti.Domain.Models;
//using UniUti.Config;
//using AutoMapper;
//using Xunit;
//using Moq;

//namespace UniUti.Test.Application.Tests.Services
//{
//    public class InstituicaoServiceTests
//    {
//        private readonly Mock<IInstituicaoRepository> _service;
//        private readonly IMapper _mapper;
//        private readonly InstituicaoService _instituicao;

//        public InstituicaoServiceTests()
//        {
//            if (_mapper == null)
//            {
//                IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//                _mapper = mapper;
//            }

//            _service = new Mock<IInstituicaoRepository>();
//            _instituicao = new InstituicaoService(_service.Object, _mapper);
//        }

//        [Fact]
//        public async Task Find_all_should_return_instituicao_success()
//        {
//            //Arrange
//            var instituicao = new List<Instituicao>()


//                new Instituicao("Teste", null, );
//                new Instituicao()
//                {
//                    Id = Guid.NewGuid(),
//                    Nome = "Teste",
//                    Deletado = false
//                }
//            };

//            //Action
//            _service.Setup(x => x.FindAll()).ReturnsAsync(instituicao);
//            var result = await _instituicao.FindAll();

//            //Assert
//            Assert.True(result.Any());
//        }

//        [Fact]
//        public async Task Find_all_should_return_null()
//        {
//            //Arrange
//            var instituicao = new List<Instituicao>();

//            //Action
//            _service.Setup(x => x.FindAll()).ReturnsAsync(instituicao);
//            var result = await _instituicao.FindAll();

//            //Assert
//            Assert.False(result.Any());
//        }

//        [Fact]
//        public async Task Find_by_id_should_return_instituicao()
//        {
//            //Arrange
//            var instituicao = new Instituicao()
//                {
//                    Id = Guid.NewGuid(),
//                    Nome = "Teste",
//                    Deletado = false
//                };

//            //Action
//            _service.Setup(x => x.FindById(It.IsAny<string>())).ReturnsAsync(instituicao);
//            var result = await _instituicao.FindById(It.IsAny<string>());

//            //Assert
//            Assert.Equal(result.Id.ToString(), instituicao.Id.ToString());
//        }

//        [Fact]
//        public async Task Delete_should_success()
//        {
//            //Arrange
//            //Action
//            _service.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);
//            var result = await _instituicao.Delete(It.IsAny<string>());

//            //Assert
//            Assert.True(true);
//        }

//        [Fact]
//        public async Task Create_success()
//        {
//            //Arrange
//            var instituicao = new Instituicao()
//            {
//                Id = Guid.NewGuid(),
//                Nome = "Teste",
//                Deletado = false
//            };

//            //Action
//            _service.Setup(x => x.Create(instituicao)).ReturnsAsync(instituicao);
//            var exception = Record.ExceptionAsync(() => _instituicao.Create(It.IsAny<InstituicaoCreateVO>())); 

//            //Assert
//            Assert.Null(exception.Exception);
//        }

//        [Fact]
//        public async Task Update_success()
//        {
//            //Arrange
//            var instituicao = new Instituicao()
//            {
//                Id = Guid.NewGuid(),
//                Nome = "Teste",
//                Deletado = false
//            };

//            //Action
//            _service.Setup(x => x.Update(instituicao)).ReturnsAsync(instituicao);
//            var exception = Record.ExceptionAsync(() => _instituicao.Update(It.IsAny<InstituicaoResponseVO>()));

//            //Assert
//            Assert.Null(exception.Exception);
//        }
//    }
//}